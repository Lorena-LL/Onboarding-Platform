import { Avatar, Card, CardContent, Divider, Stack, Typography } from "@mui/material";
import { getInitials } from "../../utils/name";
import { TEAM_CARD } from "../../constants/messages";
import type { TeamProfilesCardProps } from "./TeamProfilesCard.types";
import type { TeamMemberDto } from "../../models/team.types";
import { groupTeamMembers } from "../../utils/group";
import "./TeamProfilesCard.css";

const TeamProfilesCard: React.FC<TeamProfilesCardProps> = ({ colleagues }) => {
    const colleaguesByTeamId: Record<string, TeamMemberDto[]> = groupTeamMembers(colleagues, (colleague) => colleague.teamId);
    
    const TeamMemberRow: React.FC<{ colleague: TeamMemberDto }> = ({ colleague }) => {
        const initials = getInitials(colleague.firstName, colleague.lastName);

        return (
            <Stack direction="row" spacing={2} className="team-profiles-card__member">
                <Avatar className="team-profiles-card__avatar">{initials}</Avatar>
                <div>
                    <Typography variant="body1" className="team-profiles-card__name">
                        {colleague.firstName} {colleague.lastName}
                    </Typography>
                    <Typography variant="body2" className="team-profiles-card__role">
                        {colleague.role}
                    </Typography>
                </div>
            </Stack>
        );
    };

    return (
        <Card variant="outlined" className="team-profiles-card">
            <CardContent>
                <Typography variant="subtitle1" className="team-profiles-card__title">
                    {TEAM_CARD.title}
                </Typography>

                <Stack spacing={3}>
                    {Object.values(colleaguesByTeamId).map((teamColleagues) => (
                        <div key={teamColleagues[0].teamId}>
                            <Divider />
                            <Stack key={teamColleagues[0].teamId} spacing={1.5}>
                                <Typography variant="caption" className="team-profiles-card__team-name">
                                    {teamColleagues[0].teamName}
                                </Typography>

                                <Stack spacing={2}>
                                    {teamColleagues.map((colleague) => (
                                        <TeamMemberRow key={colleague.userId} colleague={colleague} />
                                    ))}
                                </Stack>
                            </Stack>
                        </div>
                    ))}
                </Stack>
            </CardContent>
        </Card>
    );
};

export default TeamProfilesCard;