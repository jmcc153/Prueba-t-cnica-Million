import { render, screen, fireEvent, waitFor } from "@testing-library/react"
import { describe, expect, it, vi, beforeEach } from "vitest"
import { Users } from "./users"
import { getOwners } from "@/services/owner.service"

vi.mock("@/services/owner.service", () => ({
  getOwners: vi.fn(),
}))

vi.mock("./userDetail", () => ({
  UserDetail: ({ user, setOpen }: { user: any, setOpen: (open: boolean) => void }) => (
    <div data-testid="user-detail">
      <h2>Detalle del Usuario</h2>
      <p>Nombre: {user?.name}</p>
      <button onClick={() => setOpen(false)}>Cerrar</button>
    </div>
  )
}))

describe('Users Page', () => {
  const mockUsers = [
    {
      id: "1",
      name: "Juan Pérez",
      address: "Calle 123",
      birthDate: "1990-01-01",
      photo: null
    },
    {
      id: "2",
      name: "María García",
      address: "Carrera 456",
      birthDate: "1985-05-15",
      photo: null
    }
  ]

  beforeEach(() => {
    vi.clearAllMocks()
    vi.mocked(getOwners).mockResolvedValue(mockUsers)
  })

  it('should render users table', async () => {
    render(<Users />)

    expect(screen.getByText('Usuarios')).toBeInTheDocument()
    
    await waitFor(() => {
      expect(screen.getByText('Juan Pérez')).toBeInTheDocument()
      expect(screen.getByText('María García')).toBeInTheDocument()
    })
  })

  it('should handle opening user detail', async () => {
    render(<Users />)

    await waitFor(() => {
      expect(screen.getByText('Juan Pérez')).toBeInTheDocument()
    })

    const userRow = screen.getByText('Juan Pérez').closest('tr')
    expect(userRow).toBeInTheDocument()
    
    fireEvent.click(userRow!)
    
    await waitFor(() => {
      expect(screen.getByTestId('user-detail')).toBeInTheDocument()
      expect(screen.getByText('Detalle del Usuario')).toBeInTheDocument()
      expect(screen.getByText('Nombre: Juan Pérez')).toBeInTheDocument()
    })

    expect(screen.queryByText('Usuarios')).not.toBeInTheDocument()
  })

  it('should close user detail when close button is clicked', async () => {
    render(<Users />)

    await waitFor(() => {
      expect(screen.getByText('Juan Pérez')).toBeInTheDocument()
    })

    const userRow = screen.getByText('Juan Pérez').closest('tr')
    fireEvent.click(userRow!)

    await waitFor(() => {
      expect(screen.getByTestId('user-detail')).toBeInTheDocument()
    })

    const closeButton = screen.getByText('Cerrar')
    fireEvent.click(closeButton)

    await waitFor(() => {
      expect(screen.queryByTestId('user-detail')).not.toBeInTheDocument()
      expect(screen.getByText('Usuarios')).toBeInTheDocument()
    })
  })
})
