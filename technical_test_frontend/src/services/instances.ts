import axios from 'axios'

const API_BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:3001'

export const axiosInstanceFormData = axios.create({
  baseURL: API_BASE_URL,
  timeout: 15000,
  withCredentials: true,
  headers: {
    'Content-Type': 'multipart/form-data',
    Accept: 'application/json'
  }
})

export const axiosInstanceJson = axios.create({
  baseURL: API_BASE_URL,
  timeout: 15000,
  withCredentials: true,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json'
  }
})

/* export const axiosInstanceImages = axios.create({
  baseURL: API_BASE_URL,
  timeout: 15000,
  withCredentials: true,
  responseType: 'arraybuffer',
  headers: {
    'Content-Type': 'image/png',
    Accept: 'image/png'
  }
}) */
