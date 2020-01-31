// Configurations for Frontend
const NODE_ENV = (process.env.NODE_ENV === 'production') ? 'production' : 'development'

let config = {
  url: {}
}

if (NODE_ENV === 'production') {
  config.url.api = 'http://pushlearn.ir/api/' // Change this URL according to your live server
} else {
  config.url.api = '/api/'
}

export default config
