# 🏠 Gestor de Propiedades - Frontend

Aplicación web moderna para la gestión de propiedades y propietarios, desarrollada con React, TypeScript y las mejores prácticas de desarrollo frontend.

## 📋 Tabla de Contenidos

- [🚀 Tecnologías](#-tecnologías)
- [⚡ Inicio Rápido](#-inicio-rápido)
- [📁 Estructura del Proyecto](#-estructura-del-proyecto)
- [🧩 Componentes Principales](#-componentes-principales)
- [🛣️ Rutas y Navegación](#️-rutas-y-navegación)
- [🔧 Servicios y API](#-servicios-y-api)
- [🧪 Testing](#-testing)
- [🚀 Deployment](#-deployment)
- [📖 Scripts Disponibles](#-scripts-disponibles)

## 🚀 Tecnologías

### **Framework y Lenguaje**
- **React 19.1.1** - Librería principal para UI
- **TypeScript** - Tipado estático para JavaScript
- **Vite** - Herramienta de build ultrarrápida

### **Estilizado y UI**
- **Tailwind CSS 4.1.12** - Framework de CSS utility-first
- **Shadcn UI** Biblioteca de componentes

### **Manejo de Estado y Datos**
- **React Hook Form 7.62.0** - Manejo eficiente de formularios
- **Axios 1.12.2** - Cliente HTTP para API calls

### **Navegación**
- **React Router 7.8.2** - Enrutamiento del lado del cliente

### **Testing**
- **Vitest** - Framework de testing ultrarrápido
- **Testing Library** - Utilities para testing de componentes
- **jsdom** - Simulación del DOM para testing

## ⚡ Inicio Rápido

### **Prerrequisitos**
- Node.js (versión 18 o superior)
- npm o yarn


### **Variables de Entorno**

Crea un archivo `.env` en la raíz del proyecto:

```env
VITE_API_URL=http://localhost:3001 // Modifica el puerto con el que se ejecuta el backend
```



## 📁 Estructura del Proyecto

```
src/
├── components/          # Componentes reutilizables
│   ├── ui/             # Componentes base del sistema de diseño
│   ├── dataTable/      # Componentes de tablas de datos
│   ├── modal/          # Componentes de modales
│   ├── navbar/         # Componentes de navegación
│   ├── sidebar/        # Componentes de barra lateral
│   ├── property/       # Componentes específicos de propiedades
│   └── users/          # Componentes específicos de usuarios
├── pages/              # Páginas principales de la aplicación
│   ├── home.tsx        # Página de inicio
│   ├── property/       # Páginas de propiedades
│   └── users/          # Páginas de usuarios
├── hooks/              # Custom hooks reutilizables
├── services/           # Capa de servicios para API
├── types/              # Definiciones de tipos TypeScript
├── lib/                # Utilidades y configuraciones
├── routes/             # Configuración de rutas
├── test/               # Configuración de testing
└── utils/              # Funciones utilitarias
```

## 🧩 Componentes Principales

### **Sistema de Componentes UI**

#### **DataTable**
```tsx
import { DataTable } from "@/components/dataTable/dataTable"

<DataTable
  columns={usersColumns}
  data={users}
  title="Usuarios"
  handleClick={handleUserClick}
/>
```

**Características:**
- Ordenamiento por columnas
- Filtrado integrado
- Paginación automática
- Click handlers personalizables

#### **Modal Components**
- `ModalUsers` - Modal para gestión de usuarios
- `ModalProperty` - Modal para gestión de propiedades
- `Modal` - Componente base reutilizable

### **Componentes de Página**

#### **Users (`/users`)**
- Lista de usuarios en tabla
- Detalle de usuario individual
- Formulario de creación/edición
- Navegación entre vistas

#### **Properties (`/properties`)**
- Lista de propiedades
- Filtros avanzados
- Detalle de propiedades
- Gestión de propiedades

## 🛣️ Rutas y Navegación

```tsx
// Configuración en src/routes/router.tsx
const routes = [
  { path: "/", element: <Home /> },
  { path: "/users", element: <Users /> },
  { path: "/users/:id", element: <UserDetail /> },
  { path: "/properties", element: <Properties /> },
  { path: "/properties/:id", element: <PropertyDetail /> }
]
```


## 🔧 Servicios y API

### **Configuración de Axios**

```typescript
// src/services/instances.ts
export const axiosInstanceJson = axios.create({
  baseURL: API_BASE_URL,
  timeout: 15000,
  withCredentials: true,
  headers: {
    'Content-Type': 'application/json',
  }
})

export const axiosInstanceFormData = axios.create({
  baseURL: API_BASE_URL,
  timeout: 15000,
  withCredentials: true,
  headers: {
    'Content-Type': 'multipart/form-data',
  }
})
```

### **Servicios Disponibles**

#### **Owner Service**
```typescript
// Obtener todos los propietarios
const owners = await getOwners()

// Crear nuevo propietario
const newOwner = await createOwner(formData)
```

#### **Property Service**
```typescript
// Obtener propiedades
const properties = await getProperties()

// Filtrar propiedades
const filtered = await getPropertiesFiltered(filters)
```

### **Manejo de Errores**
```typescript
try {
  const data = await getOwners()
} catch (error) {
  console.error('Error fetching owners:', error)
  // Manejo de errores UI
}
```

## 🧪 Testing

### **Configuración**
- **Framework**: Vitest + Testing Library
- **Entorno**: jsdom
- **Cobertura**: Vitest coverage

### **Ejecutar Tests**
```bash
# Tests en modo watch
npm test

# Tests una vez
npm run test:run

# Tests con UI
npm run test:ui

# Tests con cobertura
npm run test:coverage
```

### **Estructura de Tests**
```
src/
├── components/ui/button.test.tsx
├── hooks/use-mobile.test.ts
├── services/owner.service.test.ts
├── pages/users/users.test.tsx
└── lib/utils.test.ts
```

### **Ejemplo de Test**
```typescript
describe('Button Component', () => {
  it('should render with text', () => {
    render(<Button>Click me</Button>)
    expect(screen.getByText('Click me')).toBeInTheDocument()
  })

  it('should handle click events', () => {
    const handleClick = vi.fn()
    render(<Button onClick={handleClick}>Click me</Button>)
    fireEvent.click(screen.getByText('Click me'))
    expect(handleClick).toHaveBeenCalledTimes(1)
  })
})
```

## 🚀 Deployment

### **Build de Producción**
```bash
npm run build
```

### **Preview Local**
```bash
npm run preview
```

### **Optimizaciones**
- **Tree Shaking** automático con Vite
- **Code Splitting** por rutas
- **Minificación** de CSS y JS
- **Compresión** de assets

### **Variables de Entorno de Producción**
```env
VITE_API_URL=https://api.tudominio.com
```

## 📖 Scripts Disponibles

| Comando | Descripción |
|---------|-------------|
| `npm run dev` | Ejecuta el servidor de desarrollo |
| `npm run build` | Construye la aplicación para producción |
| `npm run preview` | Previsualiza el build de producción |
| `npm run lint` | Ejecuta ESLint para análisis de código |
| `npm test` | Ejecuta tests en modo watch |
| `npm run test:run` | Ejecuta tests una vez |
| `npm run test:ui` | Ejecuta tests con interfaz visual |
| `npm run test:coverage` | Ejecuta tests con reporte de cobertura |


