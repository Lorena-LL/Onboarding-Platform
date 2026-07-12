import { Button, Card, CardContent, Chip, Stack, Typography } from "@mui/material";
import ScheduleOutlinedIcon from "@mui/icons-material/ScheduleOutlined";
import { useNavigate } from "react-router-dom";
import { formatJoinedDate } from "../../utils/date";
import { ROUTES } from "../../constants/general";
import { TASK_CARD } from "../../constants/messages";
import type { TaskCardProps } from "./TaskCard.types";
import { getCategoryStyle, type CategoryStyle } from "./taskCategoryStyles";
import "./TaskCard.css";

const TaskCard: React.FC<TaskCardProps> = ({ task }: TaskCardProps) => {
    const navigate = useNavigate();
    const categoryStyle: CategoryStyle = getCategoryStyle(task.taskCategory);
    const dueDate: string = formatJoinedDate(task.dueAt);

    const handleViewTask = (): void => {
        navigate(ROUTES.taskDetails, { state: { taskId: task.id } });
    };

    return (
        <Card
            variant="outlined"
            className="task-card"
            style={{ borderLeftColor: categoryStyle.color }}
        >
            <CardContent>
                <Stack className="task-card__details">
                    <Stack spacing={1}>
                        <Typography variant="subtitle1" className="task-card__name">
                            {task.taskName}
                        </Typography>
                        <Stack direction="row" spacing={0.5} className="task-card__due">
                            <ScheduleOutlinedIcon fontSize="small" />
                            <Typography variant="body2">
                                {TASK_CARD.due} {dueDate}
                            </Typography>
                        </Stack>
                    </Stack>
                    <Chip
                        size="small"
                        icon={categoryStyle.icon as React.ReactElement}
                        label={task.taskCategory}
                        className="task-card__category"
                        style={{ color: categoryStyle.color, backgroundColor: `${categoryStyle.color}1a` }}
                    />
                </Stack>

                <Button
                    variant="outlined"
                    size="small"
                    onClick={handleViewTask}
                    className="task-card__view-button"
                >
                    {TASK_CARD.viewTask}
                </Button>
            </CardContent>
        </Card>
    );
};

export default TaskCard;