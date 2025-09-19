import type { FormProperty } from '@/types/property';
import type { InputsModalType } from '@/types/form';
import React from 'react'
import type { UseFormReturn } from 'react-hook-form';
import { Modal } from '../modal/modal';
import { CirclePlus } from 'lucide-react';

type ModalPropertyProps = {
    open: boolean;
    setOpen: (open: boolean) => void;
    form: UseFormReturn<FormProperty>;
    onSubmit: (data: FormProperty) => void;
    owners: { label: string; value: string }[];
};

export const ModalProperty = (
  { open, setOpen, form, onSubmit, owners }: ModalPropertyProps
) => {
  const inputs: InputsModalType[] = [
      {
        name: "name",
        label: "Nombre propiedad",
        type: "text",
        placeholder: "Nombre",
      },
      {
        name: "address",
        label: "Dirección propiedad",
        type: "text",
        placeholder: "Dirección",
      },
      {
        name: "price",
        label: "Precio propiedad",
        type: "number",
        placeholder: "Precio",
      },
      {
        name: "codeInternal",
        label: "Código interno",
        type: "text",
        placeholder: "Código interno",
      },
      {
        name: "year",
        label: "Año de construcción",
        type: "number",
        placeholder: "Año de construcción",
      },
      {
        name: "ownerId",
        label: "Propietario",
        type: "select",
        placeholder: "Selecciona un propietario",
        options: owners
      },
      {
        name: "images",
        label: "Fotos",
        type: "file",
        placeholder: "Sube una o más fotos",
        multiple: true,
      }
    ];
  return (
    <Modal<FormProperty>
      open={open}
      icon={CirclePlus}
      setOpen={setOpen}
      headerTitle="Agregar Propiedad"
      inputs={inputs}
      form={form}
      onSubmit={onSubmit}
    />
  );
}
