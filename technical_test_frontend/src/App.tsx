import { useState } from "react";
import { Navbar } from "./components/navbar/navbar";
import { AppSidebar } from "./components/sidebar/sidebar";
import {
  SidebarInset,
  SidebarProvider,
} from "./components/ui/sidebar";
import { Outlet } from "react-router";

function App() {
  const [open, setOpen] = useState(false);
  return (
    <>
      <SidebarProvider open={open} onOpenChange={setOpen}>
        <AppSidebar collapsible="icon" />
        <SidebarInset>
          <Navbar />
          <main className="p-10 box-border">
            <Outlet />
          </main>
        </SidebarInset>
      </SidebarProvider>
    </>
  );
}

export default App;
