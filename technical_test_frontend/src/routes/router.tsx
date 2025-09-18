import { createBrowserRouter } from "react-router";
import App from "@/App";
import { Home } from "@/pages/home";
import { Users } from "@/pages/users/users";
import { Property } from "@/pages/property";


export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "home",
        element: <Home />,
      },
      {
        path: "users",
        element: <Users />,
        children: [
        ],
      },
      {
        path: "properties",
        element: <Property />,
      }
    ],
  },
]);
