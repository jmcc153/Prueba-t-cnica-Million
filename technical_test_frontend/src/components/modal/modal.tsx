import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../ui/form";
import { useForm } from "react-hook-form";
import { Input } from "../ui/input";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "../ui/select";

import { type FC } from "react";
import type { InputsModalType } from "@/types/form";
import { Button } from "../ui/button";

type ModalProps<T extends Record<string, unknown>> = {
  open: boolean;
  setOpen: (open: boolean) => void;
  icon: FC<{ className?: string }>;
  headerTitle: string;
  inputs: InputsModalType[];
  form: ReturnType<typeof useForm<T>>;
  onSubmit: (data: T) => void;
};

export function Modal<T extends Record<string, unknown>>(props: ModalProps<T>) {
  return (
    <Dialog open={props.open} onOpenChange={props.setOpen}>
      <DialogTrigger className="cursor-pointer">
        <props.icon className="w-[28px] h-[28px]" />
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>{props.headerTitle}</DialogTitle>
        </DialogHeader>
        <Form {...props.form}>
          <form onSubmit={props.form.handleSubmit(props.onSubmit)}>
            {props.inputs.map((input) => {
              if (input.type === "select") {
                return (
                  <FormField
                    key={input.name}
                    name={input.name}
                    render={({ field }) => (
                      <FormItem className="mb-4">
                        <FormLabel>{input.label}</FormLabel>
                        <FormControl>
                          <Select
                            onValueChange={field.onChange}
                            value={field.value ?? ""}
                          >
                            <SelectTrigger className="w-full">
                              <SelectValue placeholder={input.placeholder} />
                            </SelectTrigger>
                            <SelectContent>
                              {input.options?.map((option) => (
                                <SelectItem
                                  key={option.value}
                                  value={option.value}
                                >
                                  {option.label}
                                </SelectItem>
                              ))}
                            </SelectContent>
                          </Select>
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                );
              }
               if (input.type == "file") {
                 return (
                   <FormField
                     key={input.name}
                     name={input.name}
                     render={({ field }) => (
                       <FormItem className="mb-4">
                         <FormLabel>{input.label}</FormLabel>
                         <FormControl>
                           <Input
                             placeholder={input.placeholder}
                             type={input.type}
                             accept="image/*"
                             onChange={e => {
                               if (input.multiple) {
                                 // Para archivos múltiples
                                 const files = e.target.files ? Array.from(e.target.files) : [];
                                 field.onChange(files);
                               } else {
                                 // Para archivo único
                                 const file = e.target.files?.[0] ?? null;
                                 field.onChange(file);
                               }
                             }}
                            multiple={input.multiple ?? false }
                           />
                         </FormControl>
                         <FormMessage />
                       </FormItem>
                     )}
                   />
                 );
              } else {
                return (
                  <FormField
                    key={input.name}
                    name={input.name}
                    render={({ field }) => (
                      <FormItem className="mb-4">
                        <FormLabel>{input.label}</FormLabel>
                        <FormControl>
                          <Input
                            placeholder={input.placeholder}
                            {...field}
                            value={field.value ?? ""}
                            type={input.type}
                          />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                );
              }
            })}
            <div className="flex justify-end py-4">
              <Button className="btn" type="submit">
                Guardar
              </Button>
            </div>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
}
