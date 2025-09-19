import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { MapPin, Calendar, User, ImageIcon } from "lucide-react";
import type { Users as UsersType } from "@/types/users";

export const UserDetail = ({
  user,
  setOpen,
}: {
  user: UsersType | null;
  setOpen: (open: boolean) => void;
}) => {
  return (
    <div className="container mx-auto p-6 space-y-6">
      <Button variant="outline" className="mb-4" onClick={() => setOpen(false)}>
        Volver
      </Button>

      {user ? (
        <div className="grid gap-6">
          <Card>
            <CardHeader>
              <div className="flex items-center gap-2">
                <User className="h-5 w-5" />
                <CardTitle className="text-2xl">{user.name}</CardTitle>
              </div>
              <CardDescription>
                Información personal del usuario
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-4">
              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div className="flex items-center gap-2">
                  <MapPin className="h-4 w-4 text-muted-foreground" />
                  <div>
                    <p className="text-sm font-medium text-muted-foreground">
                      Dirección
                    </p>
                    <p>{user.address}</p>
                  </div>
                </div>
                <div className="flex items-center gap-2">
                  <Calendar className="h-4 w-4 text-muted-foreground" />
                  <div>
                    <p className="text-sm font-medium text-muted-foreground">
                      Fecha de nacimiento
                    </p>
                    <p>
                      {new Date(user.birthDate).toLocaleDateString("es-CO")}
                    </p>
                  </div>
                </div>
              </div>
            </CardContent>
          </Card>

          <Card>
            <CardHeader>
              <div className="flex items-center gap-2">
                <ImageIcon className="h-5 w-5" />
                <CardTitle>Foto de perfil</CardTitle>
              </div>
            </CardHeader>
            <CardContent>
              <div className="flex justify-center">
                <img
                  src={`${import.meta.env.VITE_API_URL}/Owner/${user.id}/foto`}
                  alt={user.name}
                  className="w-48 h-48 rounded-full object-cover border-4 border-border shadow-lg"
                  loading="lazy"
                  onError={(e) => {
                    const target = e.target as HTMLImageElement;
                    target.src = "/placeholder-user.png";
                  }}
                />
              </div>
            </CardContent>
          </Card>
        </div>
      ) : (
        <Card>
          <CardContent className="p-8 text-center">
            <p className="text-muted-foreground">
              No se ha seleccionado ningún usuario
            </p>
          </CardContent>
        </Card>
      )}
    </div>
  );
};
