import request from '@/utils/request'

export function getTenant() {
  return request({
    url: '/api/identity/users',
    method: 'get'
  })
}
