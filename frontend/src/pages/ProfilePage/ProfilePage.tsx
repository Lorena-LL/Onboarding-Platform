import { useEffect, useState } from "react";
import { CircularProgress, Typography } from "@mui/material";
import PersonalProfileCard from "../../components/PersonalProfileCard/PersonalProfileCard";
import { getProfileById } from "../../services/profileService";
import { getUserId } from "../../utils/session";
import { GENERAL_ERROR } from "../../constants/errors";
import { PROFILE_PAGE } from "../../constants/messages";
import type { ProfileAllInfoResponseDto } from "../../models/profile.types";
import "./ProfilePage.css";

const ProfilePage: React.FC = () => {
    const [profile, setProfile] = useState<ProfileAllInfoResponseDto | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [errorMessage, setErrorMessage] = useState<string | null>(null);

    useEffect(() => {
        const fetchProfile = async (): Promise<void> => {
            const userId = getUserId();
            if (!userId) {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
                setIsLoading(false);
                return;
            }
            try {
                const data = await getProfileById(userId);
                setProfile(data);
            } catch {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
            } finally {
                setIsLoading(false);
            }
        };

        fetchProfile();
    }, []);

    return (
        <div className="profile-page">
            <Typography variant="h5" className="profile-page__title">
                {PROFILE_PAGE.title}
            </Typography>

            {isLoading && <CircularProgress size={28} />}
            {!isLoading && errorMessage && (
                <Typography variant="body2" color="error">{errorMessage}</Typography>
            )}
            {!isLoading && profile && <PersonalProfileCard profile={profile} />}
        </div>
    );
};

export default ProfilePage;