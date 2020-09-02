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
          <el-form-item label="用户名" prop="userName">
            <el-input v-model="form.userName" />
          </el-form-item>
          <el-form-item label="电话" prop="phoneNumber">
            <el-input v-model.number="form.phoneNumber" />
          </el-form-item>
          <el-form-item label="姓名" prop="name">
            <el-input v-model="form.name" />
          </el-form-item>
          <el-form-item label="邮箱" prop="email">
            <el-input v-model="form.email" />
          </el-form-item>
          <el-form-item label="密码" prop="password">
            <el-input v-model="form.password" type="password" />
          </el-form-item>
          <el-form-item label="状态">
            <el-radio-group v-model="form.enable" style="width: 178px">
              <el-radio label="0">禁用</el-radio>
              <el-radio label="1">启用</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="角色" prop="roles">
            <el-select v-model="checkedRole" multiple style="width: 437px" placeholder="请选择">
              <el-option
                v-for="item in roleList"
                :key="item.value"
                :label="item.label"
                :value="item.value"
              />
            </el-select>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button type="text" @click="cancel">取消</el-button>
          <el-button v-loading="formLoading" type="primary" @click="save">确认</el-button>
        </div>
      </el-dialog>
      <!--表格渲染-->
      <el-table
        ref="multipleTable"
        v-loading="listLoading"
        :data="list"
        border
        size="small"
        style="width: 100%;margin-top:10px"
        class="box-card"
        @sort-change="sortChange"
        @selection-change="handleSelectionChange"
        @row-click="handleRowClick"
      >
        <el-table-column type="selection" width="44px" />
        <el-table-column label="用户名" prop="userName" sortable="custom" align="center">
          <template slot-scope="{row}">
            <span class="link-type" @click="handleUpdate(row)">{{ row.userName }}</span>
          </template>
        </el-table-column>
        <el-table-column label="邮箱" prop="email" sortable="custom" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.email }}</span>
          </template>
        </el-table-column>
        <el-table-column label="电话" prop="phoneNumber" sortable="custom" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.phoneNumber }}</span>
          </template>
        </el-table-column>
        <el-table-column label="操作" align="center">
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
  </div></template>

<script>
import { isvalidPhone } from '@/utils/validate'
import Pagination from '@/components/Pagination'
import permission from '@/directive/permission/index.js'

export default {
  name: 'User',
  components: { Pagination },
  directives: { permission },
  data() {
    // 自定义验证
    const validPhone = (rule, value, callback) => {
      if (!value) {
        callback(new Error('请输入电话号码'))
      } else if (!isvalidPhone(value)) {
        callback(new Error('请输入正确的11位手机号码'))
      } else {
        callback()
      }
    }
    return {
      rules: {
        userName: [
          { required: true, message: '请输入用户名', trigger: 'blur' },
          { min: 2, max: 20, message: '长度在 2 到 20 个字符', trigger: 'blur' }
        ],
        name: [
          { required: true, message: '请输入用户姓名', trigger: 'blur' },
          { min: 2, max: 20, message: '长度在 2 到 20 个字符', trigger: 'blur' }
        ],
        email: [
          { required: true, message: '请输入邮箱地址', trigger: 'blur' },
          { type: 'email', message: '请输入正确的邮箱地址', trigger: 'blur' }
        ],
        phoneNumber: [
          { required: true, trigger: 'blur', validator: validPhone }
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
      this.$axios.gets('/api/identity/users', this.listQuery).then(response => {
        this.list = response.items
        this.totalCount = response.totalCount
        this.listLoading = false
      })
    },
    fetchData(id) {
      this.$axios.gets('/api/identity/users/' + id).then(response => {
        this.form = response
        this.getAllRoles()
        this.$axios.gets('/api/identity/users/' + id + '/roles').then(data => {
          this.checkedRole = []
          data.items.forEach(item => {
            this.checkedRole.push(item.name)
          })
        })
      })
    },
    getAllRoles() {
      this.roleList = []
      this.$axios.gets('/api/identity/roles/all').then(response => {
        response.items.forEach(element => {
          const options = {}
          options.value = element.name
          options.label = element.name
          this.roleList.push(options)
        })
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
          this.form.roleNames = this.checkedRole
          if (this.isEdit) {
            this.$axios
              .puts('/api/identity/users/' + this.form.id, this.form)
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
              .posts('/api/identity/users', this.form)
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
      this.formTitle = '新增用户'
      this.isEdit = false
      this.form = {}
      this.checkedRole = []
      this.dialogFormVisible = true
      this.getAllRoles()
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
              .deletes('/api/identity/users/' + row.id)
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

<style rel="stylesheet/scss" lang="scss" scoped>

</style>
