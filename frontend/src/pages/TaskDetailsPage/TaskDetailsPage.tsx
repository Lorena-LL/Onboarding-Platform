import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Button, Card, CardContent, Chip, CircularProgress, Divider, Stack, Typography } from "@mui/material";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";
import ScheduleOutlinedIcon from "@mui/icons-material/ScheduleOutlined";
import CheckCircleOutlined from "@mui/icons-material/CheckCircleOutlined";
import { completeTask, getTaskById } from "../../services/taskService";
import { formatJoinedDate } from "../../utils/date";
import { ROUTES } from "../../constants/general";
import { GENERAL_ERROR } from "../../constants/errors";
import { TASK_DETAILS_PAGE } from "../../constants/messages";
import type { AssignedOnboardingTaskDto } from "../../models/task.types";
import type { TaskDetailsLocationState } from "./TaskDetailsPage.types";
import { getCategoryStyle } from "../../components/TaskCard/taskCategoryStyles";
import { getUserId } from "../../utils/session";
import "./TaskDetailsPage.css";

const TaskDetailsPage: React.FC = () => {
    const location = useLocation();
    const navigate = useNavigate();
    const { taskId, from } = (location.state as TaskDetailsLocationState) ?? {};
    const backTo = from ?? ROUTES.activeTasks;
    const backLabel = backTo === ROUTES.completedTasks
        ? TASK_DETAILS_PAGE.backToCompletedTasks
        : TASK_DETAILS_PAGE.backToActiveTasks;

    const [task, setTask] = useState<AssignedOnboardingTaskDto | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [errorMessage, setErrorMessage] = useState<string | null>(null);
    const [isCompleting, setIsCompleting] = useState<boolean>(false);

    useEffect(() => {
        const fetchTask = async (): Promise<void> => {
            if (!taskId) {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
                setIsLoading(false);
                return;
            }
            try {
                const data = await getTaskById(taskId);
                setTask(data);
            } catch {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
            } finally {
                setIsLoading(false);
            }
        };

        fetchTask();
    }, [taskId]);

    const handleBack = (): void => {
        navigate(backTo);
    };

    const handleMarkAsComplete = async (): Promise<void> => {
        const userId = getUserId();
        if (!task || !userId) return;

        setIsCompleting(true);
        try {
            await completeTask(task.id, userId);
            setTask({ ...task, status: "Completed", completedAt: new Date().toISOString() });
        } catch {
            setErrorMessage(GENERAL_ERROR.somethingWentWrong);
        } finally {
            setIsCompleting(false);
        }
    };

    return (
        <div className="task-details-page">
            <Stack
                direction="row"
                spacing={0.5}
                className="task-details-page__back-link"
                onClick={handleBack}
            >
                <ChevronLeftIcon fontSize="small" />
                <Typography variant="body2">{backLabel}</Typography>
            </Stack>

            {isLoading && <CircularProgress size={28} className="task-details-page__spinner" />}
            {!isLoading && errorMessage && (
                <Typography variant="body2" color="error">{errorMessage}</Typography>
            )}
            {!isLoading && !errorMessage && task && (
                <Card variant="outlined" className="task-details-page__card">
                    <CardContent>
                        <Stack direction="row" spacing={1.5}>
                            <Chip
                                size="small"
                                label={task.taskCategory}
                                className="task-details-page__category"
                                style={{
                                    color: getCategoryStyle(task.taskCategory).color,
                                    backgroundColor: `${getCategoryStyle(task.taskCategory).color}1a`,
                                }}
                            />
                            <Stack direction="row" spacing={0.5} className="task-details-page__due">
                                <ScheduleOutlinedIcon fontSize="small" />
                                <Typography variant="body2">
                                    {TASK_DETAILS_PAGE.due} {formatJoinedDate(task.dueAt)}
                                </Typography>
                            </Stack>
                        </Stack>

                        <Typography variant="h4" className="task-details-page__title">
                            {task.taskName}
                        </Typography>

                        <Divider className="task-details-page__divider" />

                        <Typography variant="body1" className="task-details-page__description">
                            {task.taskDescription}
                        </Typography>

                        <Stack direction="row" spacing={2} className="task-details-page__actions">
                            <Button
                                variant="contained"
                                startIcon={<CheckCircleOutlined />}
                                onClick={handleMarkAsComplete}
                                disabled={task.status === "Completed" || isCompleting}
                                className="task-details-page__complete-button"
                            >
                                {isCompleting ? TASK_DETAILS_PAGE.markingComplete : TASK_DETAILS_PAGE.markComplete}
                            </Button>
                            <Button variant="outlined" onClick={handleBack} className="task-details-page__back-button">
                                {TASK_DETAILS_PAGE.back}
                            </Button>
                        </Stack>
                    </CardContent>
                </Card>
            )}
        </div>
    );
};

export default TaskDetailsPage;