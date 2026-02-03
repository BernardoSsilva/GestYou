import { AppSidebar } from "@/components/sidebar";
import { SidebarProvider } from "@/components/ui/sidebar";
import Image from "next/image";
import { redirect } from "next/navigation";

export default function Home() {

  redirect("/persons");

}
