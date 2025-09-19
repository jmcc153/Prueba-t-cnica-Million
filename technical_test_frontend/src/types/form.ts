export type InputsModalType = {
  name: string
  label: string
  type: string
  placeholder: string
  options?: OptionType[]
  multiple?: boolean
}

export type OptionType = {
  value: string
  label: string
}