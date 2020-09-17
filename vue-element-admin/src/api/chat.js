import request from '@/utils/request'
export function sendMessage(data) {
  return request({
    url: '/api/chat/sendmessage',
    method: 'post',
    data
  })
}
