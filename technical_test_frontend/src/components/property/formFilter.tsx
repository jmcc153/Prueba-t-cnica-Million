import React, { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "../ui/card";
import { DollarSign, MapPin, Search } from "lucide-react";
import { Input } from "../ui/input";
import { Button } from "../ui/button";
import { Slider } from "../ui/slider";

interface FormFilterProps {
  onFilter: (filters: {
    name?: string;
    address?: string;
    priceMin?: number;
    priceMax?: number;
  }) => void;
  maxPrice: number;
}

export const FormFilter = ({ onFilter, maxPrice }: FormFilterProps) => {
  const [searchTerm, setSearchTerm] = useState("");
  const [address, setAddress] = useState("");
  const [priceRange, setPriceRange] = useState([0, maxPrice]);

  useEffect(() => {
    setPriceRange([0, maxPrice]);
  }, [maxPrice]);

  const handleFilter = () => {
    const filters = {
      ...(searchTerm && { name: searchTerm }),
      ...(address && { address: address }),
      ...(priceRange[0] > 0 && { priceMin: priceRange[0] }),
      ...(priceRange[1] < maxPrice && { priceMax: priceRange[1] }),
    };
    onFilter(filters);
  };

  const clearFilters = () => {
    setSearchTerm("");
    setAddress("");
    setPriceRange([0, maxPrice]);
    onFilter({});
  };


  return (
    <Card className="mb-4">
      <CardHeader>
        <CardTitle className="flex items-center gap-2">
          <Search className="h-5 w-5" />
          Filtros de Búsqueda
        </CardTitle>
      </CardHeader>
      <CardContent>
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
          <div className="space-y-2">
            <label className="text-sm font-medium">Buscar por nombre</label>
            <div className="relative">
              <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 h-4 w-4 text-muted-foreground" />
              <Input
                placeholder="Nombre de la propiedad..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="pl-10"
              />
            </div>
          </div>

          <div className="space-y-2">
            <label className="text-sm font-medium flex items-center gap-1">
              <MapPin className="h-4 w-4" />
              Dirección
            </label>
            <Input
              placeholder="Dirección..."
              value={address}
              onChange={(e) => setAddress(e.target.value)}
            />
          </div>

          <div className="space-y-4">
            <label className="text-sm font-medium flex items-center gap-1">
              <DollarSign className="h-4 w-4" />
              Rango de precios
            </label>
            <div className="px-2">
              <Slider
                value={priceRange}
                onValueChange={setPriceRange}
                max={maxPrice}
                min={0}
                step={5000}
                className="w-full"
              />
              <div className="flex justify-between text-sm text-muted-foreground mt-2">
                <span>
                  {new Intl.NumberFormat("es-CO", {
                    style: "currency",
                    currency: "COP",
                    maximumFractionDigits: 0,
                  }).format(priceRange[0])}
                </span>
                <span>
                  {new Intl.NumberFormat("es-CO", {
                    style: "currency",
                    currency: "COP",
                    maximumFractionDigits: 0,
                  }).format(priceRange[1])}
                </span>
              </div>
            </div>
          </div>

          <div className="space-y-2 flex flex-col justify-end">
            <Button onClick={handleFilter} className="w-full">
              Aplicar Filtros
            </Button>
            <Button variant="outline" onClick={clearFilters} className="w-full">
              Limpiar
            </Button>
          </div>
        </div>
      </CardContent>
    </Card>
  );
};
