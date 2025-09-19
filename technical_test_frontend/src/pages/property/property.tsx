import { ModalProperty } from "@/components/property/modalProperty";
import { PropertyDetail } from "./propertyDetail";
import { useEffect, useState } from "react";
import { getOwners } from "@/services/owner.service";
import { createProperty, getProperty } from "@/services/property.service";

import type { Users as OwnerType } from "@/types/users";
import { useForm } from "react-hook-form";
import type { FormProperty, propertyType } from "@/types/property";
import type { OptionType } from "@/types/form";
import { DataTable } from "@/components/dataTable/dataTable";
import { propertiesColumns } from "@/components/dataTable/columns";
import { FormFilter } from "@/components/property/formFilter";

export const Property = () => {
  const [owners, setOwners] = useState<OptionType[]>([]);
  const [data, setData] = useState([]);
  const [maxPrice, setMaxPrice] = useState(1000000);
  const [openDetail, setOpenDetail] = useState(false);
  const [selectedPropertyId, setSelectedPropertyId] = useState<string | null>(null);
  const [open, setOpen] = useState(false);
  const [refetch, setRefetch] = useState(false);

  const form = useForm<FormProperty>();
  useEffect(() => {
    getOwners()
      .then((data: OwnerType[]) => {
        const formattedOwners = data.map((owner) => ({
          label: owner.name,
          value: owner.id,
        }));
        setOwners(formattedOwners);
      })
      .catch((error) => {
        console.error("Error fetching owners:", error);
      });
  }, []);

  useEffect(() => {
    getProperty()
      .then((data) => {
        setData(data);
        if (data.length > 0) {
          const max = Math.max(...data.map((property: propertyType) => property.price));
          setMaxPrice(max);
        }
      })
      .catch((error) => {
        console.error("Error fetching properties:", error);
      });
  }, [refetch]);

  const handleFilter = (filters: {
    name?: string;
    address?: string;
    priceMin?: number;
    priceMax?: number;
  }) => {
    getProperty(filters)
      .then((data) => {
        setData(data);
      })
      .catch((error) => {
        console.error("Error filtering properties:", error);
      });
  };

  const handleSubmit = (data: FormProperty) => {
    const formData = new FormData();
    formData.append("name", data.name);
    formData.append("address", data.address);
    formData.append("price", data.price.toString());
    formData.append("codeInternal", data.codeInternal);
    formData.append("year", data.year.toString());
    formData.append("ownerId", data.ownerId);

    if (data.images && data.images.length > 0) {
      data.images.forEach((file, index) => {
        formData.append(`Images[${index}].FileUrl`, file);
        formData.append(`Images[${index}].Enabled`, "true");
      });
    }

    createProperty(formData)
      .then(() => {
        setRefetch(!refetch);
        setOpen(false);
        form.reset();
      })
      .catch((error) => {
        console.error("Error creating property:", error);
      });
  };

  const handleClick = (info: propertyType) => {
    setOpenDetail(true);
    setSelectedPropertyId(info.id);
  };

  return (
    <div>
      {openDetail ? (
        <PropertyDetail id={selectedPropertyId} setOpen={setOpenDetail} />
      ) : (
        <>
          <FormFilter onFilter={handleFilter} maxPrice={maxPrice} />
          <div className="flex justify-end py-2">
            <ModalProperty
              open={open}
              setOpen={setOpen}
              form={form}
              onSubmit={handleSubmit}
              owners={owners}
            />
          </div>
          <DataTable
            columns={propertiesColumns(owners)}
            data={data}
            title="Propiedades"
            handleClick={handleClick}
          />
        </>
      )}
    </div>
  );
};
