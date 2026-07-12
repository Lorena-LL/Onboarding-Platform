import { Button, Typography } from "@mui/material";
import { LogoutOutlined } from "@mui/icons-material";
import { Link, useNavigate } from "react-router-dom";
import { COMPANY, HEADER } from "../../constants/messages";
import { ROUTES } from "../../constants/general";
import { signOut } from "../../utils/session";
import "./Header.css";

const Header: React.FC = () => {
    const navigate = useNavigate();

    const handleSignOut = () => {
        signOut();
        navigate(ROUTES.main);
    };
    
    return (
        <header className="header">
            <Link to={ROUTES.profile} className="header__brand">
                <Typography variant="body2" className="header__company">
                    {COMPANY.name}
                </Typography>
                <Typography variant="body1" className="header__product">
                    {COMPANY.product}
                </Typography>
            </Link>
            <Button
                component={Link}
                variant="outlined"
                startIcon={<LogoutOutlined fontSize="small" />}
                className="header__profile"
                onClick={handleSignOut}
            >
                {HEADER.signOut}
            </Button>
        </header>
    );
};

export default Header;