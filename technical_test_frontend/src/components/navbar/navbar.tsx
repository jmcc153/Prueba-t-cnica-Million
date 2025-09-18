import { User } from "lucide-react";
import { CustomTrigger } from "../sidebar/buttonSidebar";
import { UserMenu } from "./userMenu";

export const Navbar = () => {
  return (
    <div className="w-full h-16 flex justify-between items-center shadow-md px-2 box-border">
      <CustomTrigger />
      <h1 className="text-lg font-bold">Gestor de Propiedades</h1>
      <UserMenu />
    </div>
  );
};
