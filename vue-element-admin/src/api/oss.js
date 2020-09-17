import request from '@/utils/request'
export function policy() {
  return request({
    url: '/api/oss/policy',
    method: 'get'
  })
}

