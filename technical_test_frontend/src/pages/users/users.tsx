import { usersColumns } from "@/components/dataTable/columns";
import { DataTable } from "@/components/dataTable/dataTable";
import { ModalUsers } from "@/components/users/modalUsers";
import { createOwner, getOwners } from "@/services/owner.service";
import type { FormUsers, Users as UsersType } from "@/types/users";

import { useEffect, useState } from "react";
import { UserDetail } from "./userDetail";
import { useForm, type SubmitHandler } from "react-hook-form";

export const Users = () => {
  const [data, setData] = useState<UsersType[]>([]);
  const [openDetail, setOpenDetail] = useState(false);
  const [refetch, setRefetch] = useState(false);
  const [selectedUser, setSelectedUser] = useState<UsersType | null>(null);
  const [open, setOpen] = useState(false);
  const form = useForm<FormUsers>();

  useEffect(() => {
    getOwners().then((data: UsersType[]) => {
      setData(data);
    });
  }, [refetch]);

  const handleClick = (info: UsersType) => {
    setSelectedUser(info);
    setOpenDetail(true);
  };

  const handleSubmit: SubmitHandler<FormUsers> = (data) => {
    const maxPhotoSize = 2 * 1024 * 1024; // 2MB
    if (data.photo && data.photo.size > maxPhotoSize) {
      alert("La foto debe ser menor a 2MB");
      return;
    }
    const formData = new FormData();
    formData.append("name", data.name);
    formData.append("address", data.address);
    formData.append("birthDate", data.birthDate);
    formData.append("photo", data.photo);

    createOwner(formData).then(() => {
      setRefetch(!refetch);
      setOpen(false);
      form.reset();
    }).catch((error) => {
      console.error("Error creating owner:", error);
    });
  }


  return (
    <div>
      {openDetail ? (
        <UserDetail user={selectedUser} setOpen={setOpenDetail} />
      ) : (
        <>
          <div className="flex justify-end py-2">
            <ModalUsers open={open} setOpen={setOpen} form={form} onSubmit={handleSubmit} />
          </div>
          <DataTable
            columns={usersColumns}
            data={data}
            title="Usuarios"
            handleClick={handleClick}
          />
        </>
      )}
    </div>
  );
};
