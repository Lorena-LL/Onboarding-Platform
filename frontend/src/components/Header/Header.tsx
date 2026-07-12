import { Button, Typography } from "@mui/material";
import { PersonOutlined } from "@mui/icons-material";
import { Link } from "react-router-dom";
import { COMPANY, HEADER } from "../../constants/messages";
import { ROUTES } from "../../constants/general";
import "./Header.css";

const Header: React.FC = () => {
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
                to="/profile"
                variant="outlined"
                startIcon={<PersonOutlined fontSize="small" />}
                className="header__profile"
            >
                {HEADER.profile}
            </Button>
        </header>
    );
};

export default Header;