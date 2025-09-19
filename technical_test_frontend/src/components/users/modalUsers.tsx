import { CirclePlus } from "lucide-react";
import { Modal } from "../modal/modal";
import type { FormUsers } from "@/types/users";
import type { InputsModalType } from "@/types/form";
import type { UseFormReturn } from "react-hook-form";

type ModalUsersProps = {
  open: boolean;
  setOpen: (open: boolean) => void;
  form: UseFormReturn<FormUsers>;
  onSubmit: (data: FormUsers) => void;
};

export function ModalUsers(props: ModalUsersProps) {
  const inputs: InputsModalType[] = [
    {
      name: "name",
      label: "Nombre completo",
      type: "text",
      placeholder: "Nombre",
    },
    {
      name: "address",
      label: "Dirección",
      type: "text",
      placeholder: "Dirección",
    },
    {
      name: "birthDate",
      label: "Fecha de nacimiento",
      type: "date",
      placeholder: "Selecciona una fecha",
    },
    {
      name: "photo",
      label: "Foto",
      type: "file",
      placeholder: "Sube una foto",
    }
  ];
  return (
    <Modal<FormUsers>
      open={props.open}
      setOpen={props.setOpen}
      icon={CirclePlus}
      headerTitle="Agregar Usuario"
      inputs={inputs}
      form={props.form}
      onSubmit={props.onSubmit}
    />
  );
};
