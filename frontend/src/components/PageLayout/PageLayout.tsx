import Header from "../Header/Header";
import type { PageLayoutProps } from "./PageLayout.types";

const PageLayout: React.FC<PageLayoutProps> = ({ children }: PageLayoutProps) => {
    return (
        <div>
            <Header />
            {children}
        </div>
    );
}

export default PageLayout;