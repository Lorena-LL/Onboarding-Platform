import { Avatar, Card, CardContent, Divider, Stack, Typography } from "@mui/material";
import { formatJoinedDate } from "../../utils/date";
import { PROFILE_CARD } from "../../constants/messages";
import { getInitials } from "../../utils/name";
import type { PersonalProfileCardProps } from "./PersonalProfileCard.types";
import "./PersonalProfileCard.css";

const PersonalProfileCard: React.FC<PersonalProfileCardProps> = ({ profile }: PersonalProfileCardProps) => {
    const joinedDate = formatJoinedDate(profile.hiredDate);
    const initials = getInitials(profile.firstName, profile.lastName);

    return (
        <Card variant="outlined" className="personal-profile-card">
            <CardContent>
                <Stack direction="row" spacing={2} className="personal-profile-card__header">
                    <Avatar className="personal-profile-card__avatar"> {initials} </Avatar>
                    <div>
                        <Typography variant="h6" className="personal-profile-card__name">
                            {profile.firstName} {profile.lastName}
                        </Typography>
                        <Typography variant="body2" className="personal-profile-card__subtitle">
                            {profile.role} · {PROFILE_CARD.joined} {joinedDate}
                        </Typography>
                    </div>
                </Stack>

                <Divider />

                <Stack direction="row" spacing={6} className="personal-profile-card__body">
                    <Stack className="personal-profile-card__field">
                        <Typography variant="button" className="personal-profile-card__label">
                            {PROFILE_CARD.email}
                        </Typography>
                        <Typography variant="body1">{profile.email}</Typography>
                    </Stack>
                </Stack>
            </CardContent>
        </Card>
    );
};

export default PersonalProfileCard;