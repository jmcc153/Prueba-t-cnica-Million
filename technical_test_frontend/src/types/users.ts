export type Users = {
  id: string
  name: string
  address: string
  birthDate: string
}

export type FormUsers = {
  name: string
  address: string
  birthDate: string
  photo: File
}



export type InputsModalType = {
  name: string
  label: string
  type: string
  placeholder: string
  options?: { value: string; label: string }[]
}