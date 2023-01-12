import { FunctionComponent, PropsWithChildren } from 'react';
import Footer from './Footer';
import Header from './Header';

const Page = (props: PropsWithChildren<any>) => {
    
    return (
        <div>
            <Header />
            {props.children}
            <Footer />
        </div>
    )
}

  export default Page;
