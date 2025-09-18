import { useSidebar } from "@/components/ui/sidebar";
import { PanelRightClose, PanelRightOpen } from "lucide-react";

export function CustomTrigger() {
  const { toggleSidebar, open } = useSidebar();

  return (
    <button className={"cursor-pointer"} onClick={toggleSidebar}>
      {!open ? <PanelRightClose /> : <PanelRightOpen />}
    </button>
  );
}
