import { 
    WorkOutlineOutlined, 
    ChatBubbleOutlineOutlined, 
    BuildOutlined, 
    CardGiftcardOutlined, 
    CategoryOutlined 
} from "@mui/icons-material";

export interface CategoryStyle {
    color: string;
    icon: React.ReactNode;
}

const DEFAULT_CATEGORY_STYLE: CategoryStyle = {
    color: "#64748b",
    icon: <CategoryOutlined fontSize="small" />,
};

const CATEGORY_STYLES: Record<string, CategoryStyle> = {
    "Workplace And Scheduling": { color: "#2563eb", icon: <WorkOutlineOutlined fontSize="small" /> },
    "Communication Tools": { color: "#16a34a", icon: <ChatBubbleOutlineOutlined fontSize="small" /> },
    "Technical": { color: "#9333ea", icon: <BuildOutlined fontSize="small" /> },
    "Company Benefits": { color: "#ea580c", icon: <CardGiftcardOutlined fontSize="small" /> },
};

export const getCategoryStyle = (category: string): CategoryStyle =>
    CATEGORY_STYLES[category] ?? DEFAULT_CATEGORY_STYLE;