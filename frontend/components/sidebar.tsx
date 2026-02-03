import { title } from "process";
import { Sidebar, SidebarContent, SidebarFooter, SidebarGroup, SidebarGroupContent, SidebarGroupLabel, SidebarHeader, SidebarMenu, SidebarMenuButton, SidebarMenuItem } from "./ui/sidebar";
import { ChartBarStacked, CircleUser, Icon, SquareStack, UserRoundSearch, Wallet } from "lucide-react";

export function AppSidebar() {
    const items = [
        {
            title: 'Pessoas',
            url: 'persons',
            icon: CircleUser
        },
        {
            title: 'Categorias',
            url: 'categories',
            icon: ChartBarStacked
        },
        {
            title: 'Transações',
            url: 'transactions',
            icon: Wallet
        },
        {
            title: 'Transações por pessoa',
            url: 'totalPerPerson',
            icon: UserRoundSearch
        },

        {
            title: 'Transações por categoria',
            url: 'totalPerCategory',
            icon: SquareStack
        },

    ]
    return (

        <Sidebar>


            <SidebarContent>
                <SidebarGroup>
                    <SidebarGroupLabel>
                        <h1>
                            GestYou
                        </h1>
                    </SidebarGroupLabel>
                    <SidebarGroupContent>
                        <SidebarMenu>
                            {items.map((item) => (
                                <SidebarMenuItem key={item.title}>
                                    <SidebarMenuButton asChild>
                                        <a href={item.url}>
                                            <item.icon />
                                            <span>{item.title}</span>
                                        </a>
                                    </SidebarMenuButton>
                                </SidebarMenuItem>
                            ))}
                        </SidebarMenu>
                    </SidebarGroupContent>
                </SidebarGroup>
            </SidebarContent>
            <SidebarFooter />
        </Sidebar>
    )

}