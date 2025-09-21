import { describe, it, expect } from 'vitest'
import { render, screen } from '@testing-library/react'
import { Home } from './home'

describe('Home Page', () => {
  it('should render welcome message', () => {
    render(<Home />)

    expect(screen.getByText('Bienvenido a tu aplicación para gestión de propiedades')).toBeInTheDocument()
  })

})