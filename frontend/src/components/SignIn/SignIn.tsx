import { useState } from "react";
import axios from "axios";
import { EMPTY_STRING } from "../../constants/general";
import { Button, IconButton, InputAdornment, TextField, Typography } from "@mui/material";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import { login } from "../../services/authService";
import type { AuthResponseDto } from "../../models/auth.types";
import type { SignInFormState, SignInProps } from "./SignIn.types";
import { GENERAL_ERROR, SIGN_IN_ERROR } from "../../constants/errors";
import { CREDENTIALS, SIGN_IN } from "../../constants/messages";
import "./SignIn.css";

const SignIn: React.FC<SignInProps> = ({ onSignInSuccess }) => {
    const [formState, setFormState] = useState<SignInFormState>({
        email: EMPTY_STRING,
        password: EMPTY_STRING,
    });
    const [errorMessage, setErrorMessage] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [showPassword, setShowPassword] = useState<boolean>(false);

    const handleSubmit = async (
        event: React.FormEvent<HTMLFormElement>
    ): Promise<void> => {
        event.preventDefault();
        setErrorMessage(null);
        setIsLoading(true);

        try {
            const responnse: AuthResponseDto = await login(formState);
            onSignInSuccess(responnse);
        } catch (error: unknown) {
            if (axios.isAxiosError(error)) {
                setErrorMessage(SIGN_IN_ERROR.invalidCredentials);
            } else {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
            }
        } finally {
            setIsLoading(false);
        }
    };

    const handleChange = (field: keyof SignInFormState) =>
        (event: React.ChangeEvent<HTMLInputElement>): void => {
            setFormState((prev) => ({ ...prev, [field]: event.target.value}));
        };

    const handleTogglePasswordVisibility = (): void => {
        setShowPassword((prev) => !prev);
    };

    return (
        <div className="sign-in">
            <Typography variant="h4" component="h1" className="sign-in__title">
                {SIGN_IN.title}
            </Typography>
            <Typography variant="body1" className="sign-in__subtitle">
                {SIGN_IN.subtitle}
            </Typography>
            <form className="sign-in__form" onSubmit={handleSubmit}>
                <div className="sign-in__field">
                    <Typography
                        variant="body2"
                        component="label"
                        htmlFor="email"
                        className="sign-in__label"
                    >
                        {CREDENTIALS.email}
                    </Typography>
                    <TextField
                        id="email"
                        type="email"
                        placeholder={CREDENTIALS.placeholderEmail}
                        value={formState.email}
                        onChange={handleChange("email")}
                        required
                        fullWidth
                        variant="outlined"
                        className="sign-in__input"
                    />
                </div>

                <div className="sign-in__field">
                    <Typography
                        variant="body2"
                        component="label"
                        htmlFor="password"
                        className="sign-in__label"
                    >
                        {CREDENTIALS.password}
                    </Typography>
                    <TextField
                        id="password"
                        type={showPassword ? "text" : "password"}
                        placeholder={CREDENTIALS.placeholderPassword}
                        value={formState.password}
                        onChange={handleChange("password")}
                        required
                        fullWidth
                        variant="outlined"
                        className="sign-in__input"
                        slotProps={{
                            input: {
                                endAdornment: (
                                    <InputAdornment position="end">
                                    <IconButton
                                        aria-label="toggle password visibility"
                                        onClick={handleTogglePasswordVisibility}
                                        edge="end"
                                    >
                                        {showPassword ? <VisibilityOff /> : <Visibility />}
                                    </IconButton>
                                    </InputAdornment>
                                ),
                            }
                        }}
                    />
                </div>

                {errorMessage && (
                    <Typography variant="body2" className="sign-in__error">
                        {errorMessage}
                    </Typography>
                )}

                <Button
                    type="submit"
                    variant="contained"
                    fullWidth
                    disabled={isLoading}
                    className="sign-in__submit"
                >
                    {isLoading ? SIGN_IN.signingIn : SIGN_IN.title}
                </Button>
            </form>

            <Typography variant="body2" className="sign-in__footer">
                {SIGN_IN.noAccount}
            </Typography>
        </div>
    )
};

export default SignIn;