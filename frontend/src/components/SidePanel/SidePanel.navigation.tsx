import { PersonOutlined } from "@mui/icons-material";
import { SIDE_PANEL } from "../../constants/messages";
import { ROUTES } from "../../constants/general";

export interface NavItem {
    label: string;
    path: string;
    icon: React.ReactNode;
}

export const NAV_ITEMS: NavItem[] = [
    { label: SIDE_PANEL.personalDetails, path: ROUTES.profile, icon: <PersonOutlined fontSize="small" /> },
];