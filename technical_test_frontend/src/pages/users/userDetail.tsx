import { Button } from "@/components/ui/button";
import type { Users as UsersType } from "@/types/users"

export const UserDetail = (
  { user, setOpen }: { user: UsersType | null; setOpen: (open: boolean) => void }
) => {
  return (
    <div>
      <Button variant="outline" className="mb-4" onClick={() => setOpen(false)}>Volver</Button>
      {user ? (
        <>
          <h2>{user.name}</h2>
          <p>Direccion: {user.address}</p>
          <p>Fecha de nacimiento: {user.birthDate}</p>
          <img src={`${import.meta.env.VITE_API_URL}/Owner/${user.id}/foto`} alt={user.name} />
        </>
      ) : (
        <p>No user selected</p>
      )}
    </div>
  )
}
