<template>
  <div class="app-container">
    <!--工具栏-->
    <div class="head-container">
      <!-- 搜索 -->
      <el-input
        v-model="listQuery.Filter"
        clearable
        size="small"
        placeholder="搜索..."
        style="width: 200px;"
        class="filter-item"
        @keyup.enter.native="handleFilter"
      />
      <el-button
        class="filter-item"
        size="mini"
        type="success"
        icon="el-icon-search"
        @click="handleFilter"
      >    {{ $t('base.search') }}</el-button>
      <el-button
        class="filter-item"
        size="mini"
        type="warning"
        icon="el-icon-refresh-left"
        @click="resetQuery"
      >{{ $t('base.reset') }}</el-button>
      <el-button
        v-permission="['AbpIdentity.Users.Create']"
        class="filter-item"
        size="mini"
        type="primary"
        icon="el-icon-plus"
        @click="handleCreate"
      >{{ $t('base.add') }}</el-button>
      <el-button
        v-permission="['AbpIdentity.Users.Update']"
        class="filter-item"
        size="mini"
        type="success"
        icon="el-icon-edit"
        @click="handleUpdate()"
      >{{ $t('base.edit') }}</el-button>
      <el-button
        slot="reference"
        v-permission="['AbpIdentity.Users.Delete']"
        class="filter-item"
        type="danger"
        icon="el-icon-delete"
        size="mini"
        @click="handleDelete()"
      >{{ $t('base.delete') }}</el-button>
    </div>
    <!--表单渲染-->
    <el-dialog
      :visible.sync="dialogFormVisible"
      :close-on-click-modal="false"
      :title="formTitle"
      width="570px"
    >
      <el-form
        ref="form"
        :inline="true"
        :model="form"
        :rules="rules"
        size="small"
        label-width="66px"
      >
        <el-form-item label="用户名" prop="name">
          <el-input v-model="form.name" />
        </el-form-item>
        <el-form-item v-show="isEdit==false" label="管理员邮箱">
          <el-input v-model="form.adminEmailAddress" />
        </el-form-item>
        <el-form-item v-show="!isEdit" label="管理员密码">
          <el-input v-model="form.adminPassword" />
        </el-form-item>
      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button type="text" @click="cancel">{{ $t('base.cancel') }}</el-button>
        <el-button v-loading="formLoading" type="primary" @click="save">{{ $t('base.corfim') }}</el-button>
      </div>
    </el-dialog>
    <!--表格渲染-->
    <el-table
      ref="multipleTable"
      v-loading="listLoading"
      :data="list"
      size="small"
      style="width: 100%;"
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      @row-click="handleRowClick"
    >
      <el-table-column type="selection" width="44px" />
      <el-table-column :label="$t(&quot;tenant.table.id&quot;)" sortable="custom" align="center">
        <template slot-scope="{row}">
          <span class="link-type" @click="handleUpdate(row)">{{ row.id }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t(&quot;tenant.table.name&quot;)" prop="name" sortable="custom" align="center">
        <template slot-scope="{row}">
          <span class="link-type" @click="handleUpdate(row)">{{ row.name }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t(&quot;base.operation&quot;)" align="center" width="125">
        <template slot-scope="{row}">
          <el-button
            v-permission="['AbpIdentity.Users.Update']"
            type="primary"
            size="mini"
            icon="el-icon-edit"
            @click="handleUpdate(row)"
          />
          <el-button
            v-permission="['AbpIdentity.Users.Delete']"
            type="danger"
            size="mini"
            :disabled="row.userName==='admin'"
            icon="el-icon-delete"
            @click="handleDelete(row)"
          />
        </template>
      </el-table-column>
    </el-table>
    <pagination
      v-show="totalCount>0"
      :total="totalCount"
      :page.sync="page"
      :limit.sync="listQuery.MaxResultCount"
      @pagination="getList"
    />
  </div>
</template>

<script>
// import { isvalidPhone } from '@/utils/validate'
import Pagination from '@/components/Pagination'
import permission from '@/directive/permission/index.js'
// import { getTenant } from '@/api/tenant'
export default {
  name: 'Tenant',
  components: { Pagination },
  directives: { permission },
  data() {
    // 自定义验证
    return {
      rules: {
        name: [
          { required: true, message: '请输入用户姓名', trigger: 'blur' },
          { min: 2, max: 20, message: '长度在 2 到 20 个字符', trigger: 'blur' }
        ]
      },
      form: {},
      list: null,
      roleList: [],
      checkedRole: [],
      totalCount: 0,
      listLoading: true,
      formLoading: false,
      listQuery: {
        Filter: '',
        Sorting: '',
        SkipCount: 0,
        MaxResultCount: 10
      },
      page: 1,
      dialogFormVisible: false,
      multipleSelection: [],
      formTitle: '',
      isEdit: false
    }
  },
  created() {
    this.getList()
  },
  methods: {
    getList() {
      this.listLoading = true
      this.listQuery.SkipCount = (this.page - 1) * 10
      this.$axios.gets('/api/multi-tenancy/tenants', this.listQuery).then(response => {
        this.list = response.items
        this.totalCount = response.totalCount
        this.listLoading = false
      })
    },

    handleFilter() {
      this.page = 1
      this.getList()
    },
    resetQuery() {},
    save() {
      this.$refs.form.validate(valid => {
        if (valid) {
          this.formLoading = true

          if (this.isEdit) {
            this.$axios
              .puts('/api/multi-tenancy/tenants/' + this.form.id, this.form)
              .then(response => {
                this.formLoading = false
                this.$notify({
                  title: '成功',
                  message: '更新成功',
                  type: 'success',
                  duration: 2000
                })
                this.dialogFormVisible = false
                this.getList()
              })
              .catch(() => {
                this.formLoading = false
              })
          } else {
            this.$axios
              .posts('/api/multi-tenancy/tenants', this.form)
              .then(response => {
                this.formLoading = false
                this.$notify({
                  title: '成功',
                  message: '新增成功',
                  type: 'success',
                  duration: 2000
                })
                this.dialogFormVisible = false
                this.getList()
              })
              .catch(() => {
                this.formLoading = false
              })
          }
        }
      })
    },
    handleCreate() {
      this.formTitle = this.$t('tenant.form.addTitle')
      this.isEdit = false
      this.form = {}
      this.checkedRole = []
      this.dialogFormVisible = true
    },
    handleDelete(row) {
      if (row) {
        this.$confirm('是否删除' + row.name + '?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        })
          .then(() => {
            this.$axios
              .deletes('/api/multi-tenancy/tenants/' + row.id)
              .then(response => {
                const index = this.list.indexOf(row)
                this.list.splice(index, 1)
                this.$notify({
                  title: '成功',
                  message: '删除成功',
                  type: 'success',
                  duration: 2000
                })
              })
          })
          .catch(() => {
            this.$message({
              type: 'info',
              message: '已取消删除'
            })
          })
      } else {
        this.$alert('暂时不支持用户批量删除', '提示', {
          confirmButtonText: '确定',
          callback: action => {
            //
          }
        })
      }
    },
    handleUpdate(row) {
      this.formTitle = '修改用户'
      this.isEdit = true

      if (row) {
        this.fetchData(row.id)
        this.dialogFormVisible = true
      } else {
        if (this.multipleSelection.length !== 1) {
          this.$message({
            message: '编辑必须选择单行',
            type: 'warning'
          })
          return
        } else {
          this.fetchData(this.multipleSelection[0].id)
          this.dialogFormVisible = true
        }
      }
    },

    fetchData(id) {
      this.$axios.gets('/api/multi-tenancy/tenants/' + id).then(response => {
        this.form = response
      })
    },
    sortChange(data) {
      const { prop, order } = data
      if (!prop || !order) {
        this.handleFilter()
        return
      }
      this.listQuery.Sorting = prop + ' ' + order
      this.handleFilter()
    },
    handleSelectionChange(val) {
      this.multipleSelection = val
    },
    handleRowClick(row, column, event) {
      this.$refs.multipleTable.clearSelection()
      this.$refs.multipleTable.toggleRowSelection(row)
    },
    cancel() {
      this.dialogFormVisible = false
      this.$refs.form.clearValidate()
    }
  }
}
</script>

