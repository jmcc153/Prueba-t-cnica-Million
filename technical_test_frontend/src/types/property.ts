export type propertyType = {
  id: string
  name: string
  address: string
  price: number
  codeInternal: string
  year: string,
  ownerId: string
}

export type propertyTypeInfo = {
  id: string
  name: string
  address: string
  price: number
  codeInternal: string
  year: string
  ownerId: string
  ownerInfo: {
    name: string
    address: string
    birthDate: string
    photo: string
  }
  traces: {
    dateSale: string
    name: string
    value: number
    tax: number
  }[]
  images: {
    enabled: boolean
    fileUrl: string
    src: string
  }[]
}

export type FormProperty = {
  name: string
  address: string
  price: number
  codeInternal: string
  year: number
  ownerId: string
  images: File[]
}

export type FormFilterProperty = {
  name?: string
  address?: string
  priceMin?: number
  priceMax?: number
}