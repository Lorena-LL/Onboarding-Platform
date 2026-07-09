import { useNavigate } from "react-router-dom";
import SignIn from "../components/SignIn/SignIn";
import { setToken } from "../utils/session";
import { COMPANY, SIGN_IN_PAGE } from "../constants/messages";
import type { AuthResponseDto } from "../models/auth.types";
import "./SignInPage.css";
import { Typography } from "@mui/material";

const SignInPage: React.FC = () => {
    const navigate = useNavigate();

    const handleSignInSuccess = (data: AuthResponseDto): void => {
        setToken(data.token);
        navigate("/home");
    };

    return (
        <div className="sign-in-page">
            <div className="sign-in-page__brand">
                <Typography variant="body1" className="sign-in-page__logo">
                    {COMPANY.name}
                </Typography>
                <Typography variant="h2" className="sign-in-page__heading">
                    {SIGN_IN_PAGE.heading}
                </Typography>
                <Typography variant="h6" className="sign-in-page__description">
                    {SIGN_IN_PAGE.description}
                </Typography>
            </div>
            <div className="sign-in-page__panel">
                <SignIn onSignInSuccess={handleSignInSuccess} />
            </div>
        </div>
    );
};

export default SignInPage;