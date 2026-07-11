import { List, ListItemButton, ListItemIcon, ListItemText, Typography } from "@mui/material";
import { useLocation, useNavigate } from "react-router-dom";
import { SIDE_PANEL } from "../../constants/messages";
import { NAV_ITEMS, type NavItem } from "./SidePanel.navigation";
import "./SidePanel.css";

const SidePanel: React.FC = () => {
    const location = useLocation();
    const navigate = useNavigate();

    return (
        <nav className="side-panel">
            <Typography variant="overline" className="side-panel__title">
                {SIDE_PANEL.navigation}
            </Typography>
            <List className="side-panel__list">
                {NAV_ITEMS.map((item: NavItem) => (
                    <ListItemButton
                        key={item.path}
                        selected={location.pathname === item.path}
                        onClick={() => navigate(item.path)}
                        className="side-panel__item"
                    >
                        <ListItemIcon className="side-panel__icon">{item.icon}</ListItemIcon>
                        <ListItemText primary={item.label} />
                    </ListItemButton>
                ))}
            </List>
        </nav>
    );
};

export default SidePanel;