import type { FormUsers } from '@/types/users'
import { axiosInstanceFormData, axiosInstanceJson } from './instances'

export async function getOwners() {
  const response = await axiosInstanceJson.get(`/owner`)
  if (response) return response.data
  throw response
}

export async function createOwner (data : FormUsers | FormData) {
  const response = await axiosInstanceFormData.post('/owner', data)
  if (response) return response.data
  throw response
}
/* export async function createUser (data) {
  const response = await axiosInstanceJson.post('/user', data)
  if (response) return response.data
  throw response
}
export async function updateUser (id, data) {
  const response = await axiosInstanceFormData.put(`/user/${id}`, data)
  if (response) return response.data
  throw response
}
export async function updateRating (id, data) {
  const response = await axiosInstanceFormData.post(`/user/calification/${id}`, data)
  if (response) return response.data
  throw response
}
export async function getRatingUser (id) {
  const response = await axiosInstanceJson.get(`/user/calification/${id}`)
  if (response) return response.data
  throw response
}
export const getProductByUserID = async (id) => {
  const response = await axiosInstanceJson.get(`user/products/${id}`)
  if (response) return response
  throw response
} */
