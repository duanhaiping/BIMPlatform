<template>
  <div class="app-container">
    <h1>Chat</h1>
    <div class="head-container">
      <div>All Messages:</div>
      <ul id="MessageList" style="">
        <li v-for="(message,index) in messageList " :key="index"><strong><i class="fas fa-long-arrow-alt-right" /> {{ message }}</strong></li>
      </ul>
      <el-form
        ref="form"
        :inline="true"
        :model="form"

        size="small"
        label-width="66px"
      >
        <el-form-item label="Target user" prop="name">
          <el-input v-model="form.TargetUserName" style="width: 380px;" />
        </el-form-item>
        <el-form-item label="Message">
          <el-input v-model="form.Message" style="width: 380px;" />
        </el-form-item>
        <el-form-item label="">
          <el-button size="small" type="text" @click="sendMessage">SendMessageButton</el-button>

        </el-form-item>
      </el-form></div>
  </div>
</template>
<script>
import * as signalR from '@microsoft/signalr'
import { sendMessage } from '@/api/chat'

export default {
  name: 'Chat',
  components: { signalR },
  data() {
    return {
      form: {},
      formLoading: false,
      messageList: [],
      formTitle: '',
      isEdit: false

    }
  },
  created() {
    var connection = new signalR.HubConnectionBuilder().withUrl('https://localhost:44312/signalr-hubs/chat').build()

    connection.on('ReceiveMessage', function(message) {
      this.messageList.push(message)
    })

    connection.start().then(function() {

    }).catch(function(err) {
      return console.error(err.toString())
    })
  },
  methods: {
    sendMessage() {
      return new Promise((resolve, reject) => {
        sendMessage(this.form).then(response => {
          resolve(true)
        }).catch(err => {
          console.log(err)
          reject(false)
        })
      })
    }
  }
}
</script>
<style scoped>
#MessageList {
    border: 1px solid gray;
    height: 400px;
    overflow: auto;
    list-style: none;
    padding-left: 0;
    padding: 10px;
}

#TargetUser {
    width: 100%;
}

#Message {
    width: 100%;
}
</style>
