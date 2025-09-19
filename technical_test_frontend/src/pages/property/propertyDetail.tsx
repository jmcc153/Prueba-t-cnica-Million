import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { getPropertyById } from "@/services/property.service";
import { type propertyTypeInfo } from "@/types/property";
import { useEffect, useState } from "react";
import {
  MapPin,
  DollarSign,
  Calendar,
  User,
  FileText,
  ImageIcon,
} from "lucide-react";
export const PropertyDetail = ({
  id,
  setOpen,
}: {
  id: string | null;
  setOpen: (open: boolean) => void;
}) => {
  const [propertyInfo, setPropertyInfo] = useState<propertyTypeInfo | null>(
    null
  );

  useEffect(() => {
    getPropertyById(id)
      .then((data) => {
        setPropertyInfo(data);
      })
      .catch((error) => {
        console.error("Error fetching property by id:", error);
      });
  }, [id]);

  return (
    <div>
      <Button variant="outline" className="mb-4" onClick={() => setOpen(false)}>
        Volver
      </Button>

      {propertyInfo ? (
        <div className="grid gap-6">
          {/* Información Principal */}
          <Card>
            <CardHeader>
              <div className="flex items-center gap-2">
                <FileText className="h-5 w-5" />
                <CardTitle className="text-2xl">{propertyInfo.name}</CardTitle>
              </div>
              <CardDescription>
                Código interno: {propertyInfo.codeInternal}
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-4">
              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div className="flex items-center gap-2">
                  <MapPin className="h-4 w-4 text-muted-foreground" />
                  <span>{propertyInfo.address}</span>
                </div>
                <div className="flex items-center gap-2">
                  <DollarSign className="h-4 w-4 text-muted-foreground" />
                  Precio:
                  <span className="font-semibold">
                    {new Intl.NumberFormat("es-CO", {
                      style: "currency",
                      currency: "COP",
                      maximumFractionDigits: 0,
                    }).format(propertyInfo.price)}
                  </span>
                </div>
                <div className="flex items-center gap-2">
                  <Calendar className="h-4 w-4 text-muted-foreground" />
                  <span>Año de construcción: {propertyInfo.year}</span>
                </div>
              </div>
            </CardContent>
          </Card>

          <Card>
            <CardHeader>
              <div className="flex items-center gap-2">
                <User className="h-5 w-5" />
                <CardTitle>Información del Propietario</CardTitle>
              </div>
            </CardHeader>
            <CardContent className="space-y-3">
              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div>
                  <p className="text-sm font-medium text-muted-foreground">
                    Nombre
                  </p>
                  <p className="font-semibold">{propertyInfo.ownerInfo.name}</p>
                </div>
                <div>
                  <p className="text-sm font-medium text-muted-foreground">
                    Dirección
                  </p>
                  <p>{propertyInfo.ownerInfo.address}</p>
                </div>
                <div>
                  <p className="text-sm font-medium text-muted-foreground">
                    Fecha de nacimiento
                  </p>
                  <p>
                    {new Date(
                      propertyInfo.ownerInfo.birthDate
                    ).toLocaleDateString("es-CO")}
                  </p>
                </div>
              </div>
              {propertyInfo.ownerInfo.photo && (
                <div className="mt-4">
                  <p className="text-sm font-medium text-muted-foreground mb-2">
                    Foto del propietario
                  </p>
                  <img
                    src={`${import.meta.env.VITE_API_URL}/Owner/${
                      propertyInfo.ownerId
                    }/foto`}
                    alt="Propietario"
                    className="w-24 h-24 rounded-full object-cover border-2 border-border"
                  />
                </div>
              )}
            </CardContent>
          </Card>

          {propertyInfo.traces && propertyInfo.traces.length > 0 && (
            <Card>
              <CardHeader>
                <CardTitle>Historial de Transacciones</CardTitle>
                <CardDescription>
                  Registro de ventas y transacciones
                </CardDescription>
              </CardHeader>
              <CardContent>
                <div className="space-y-3">
                  {propertyInfo.traces.map((trace, index) => (
                    <div
                      key={index}
                      className="border rounded-lg p-4 space-y-2"
                    >
                      <div className="flex justify-between items-start">
                        <div>
                          <p className="font-semibold">{trace.name}</p>
                          <p className="text-sm text-muted-foreground">
                            {new Date(trace.dateSale).toLocaleDateString(
                              "es-CO"
                            )}
                          </p>
                        </div>
                        <div className="text-right">
                          <p className="font-semibold text-green-600">
                            {new Intl.NumberFormat("es-CO", {
                              style: "currency",
                              currency: "COP",
                              maximumFractionDigits: 0,
                            }).format(trace.value)}
                          </p>
                          <p className="text-sm text-muted-foreground">
                            Impuesto:
                            {new Intl.NumberFormat("es-CO", {
                              style: "currency",
                              currency: "COP",
                              maximumFractionDigits: 0,
                            }).format(trace.tax)}
                          </p>
                        </div>
                      </div>
                    </div>
                  ))}
                </div>
              </CardContent>
            </Card>
          )}

          {propertyInfo.images && propertyInfo.images.length > 0 && (
            <Card>
              <CardHeader>
                <div className="flex items-center gap-2">
                  <ImageIcon className="h-5 w-5" />
                  <CardTitle>Galería de Imágenes</CardTitle>
                </div>
              </CardHeader>
              <CardContent>
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                  {propertyInfo.images.map((image, index) => (
                    <div key={index} className="relative group">
                      <img
                        src={image.src}
                        alt={`Imagen de la propiedad ${index + 1}`}
                        className="w-full h-48 object-cover rounded-lg border shadow-sm hover:shadow-md transition-shadow"
                      />
                    </div>
                  ))}
                </div>
              </CardContent>
            </Card>
          )}
        </div>
      ) : (
        <Card>
          <CardContent className="p-8 text-center">
            <p className="text-muted-foreground">
              Cargando información de la propiedad...
            </p>
          </CardContent>
        </Card>
      )}
    </div>
  );
};
