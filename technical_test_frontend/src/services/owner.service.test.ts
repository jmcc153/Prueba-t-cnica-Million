import { describe, it, expect, vi, beforeEach } from 'vitest'
import { getOwners, createOwner } from './owner.service'
import { axiosInstanceJson, axiosInstanceFormData } from './instances'

vi.mock('./instances', () => ({
  axiosInstanceJson: {
    get: vi.fn(),
  },
  axiosInstanceFormData: {
    post: vi.fn(),
  },
}))

describe('Owner Service', () => {
  beforeEach(() => {
    vi.clearAllMocks()
  })

  describe('getOwners', () => {
    it('should return owners data when request is successful', async () => {
      const mockOwners = [
        { id: '1', name: 'Juan Pérez', address: 'Calle 123', birthDate: '1990-01-01' },
        { id: '2', name: 'María García', address: 'Carrera 456', birthDate: '1985-05-15' }
      ]

      vi.mocked(axiosInstanceJson.get).mockResolvedValue({
        data: mockOwners
      })

      const result = await getOwners()

      expect(axiosInstanceJson.get).toHaveBeenCalledWith('/owner')
      expect(result).toEqual(mockOwners)
    })
  })

  describe('createOwner', () => {
    it('should create owner with FormData successfully', async () => {
      const mockFormData = new FormData()
      mockFormData.append('name', 'Test User')
      mockFormData.append('address', 'Test Address')
      mockFormData.append('birthDate', '1990-01-01')
      const mockFile = new File(['mock content'], 'photo.jpg', { type: 'image/jpeg' })
      mockFormData.append('photo', mockFile)

      const mockResponse ='Owner created'

      vi.mocked(axiosInstanceFormData.post).mockResolvedValue({
        data: mockResponse
      })

      const result = await createOwner(mockFormData)

      expect(axiosInstanceFormData.post).toHaveBeenCalledWith('/owner', mockFormData)
      expect(result).toEqual(mockResponse)
    })
  })
})