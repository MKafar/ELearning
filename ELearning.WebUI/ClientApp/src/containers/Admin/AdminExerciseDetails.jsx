import React, {Component} from 'react';
import {Header} from 'semantic-ui-react';

import './AdminExerciseDetails';
import CodeWindow from '../../components/Modules/CodeWindow';
class AdminExerciseDetails extends Component {



    render() {
        //zmienianie string na html
        // const htmlString = '<div>Hello World</div>';
        // const v = 6;
        // function createMarkup() {
        //     return {__html: htmlString};
        //   }
          
    

        return (
            <div className='container'>
                <div className='codingContainer'>
                    <Header size='large'>Szczegóły zadania</Header>
                    {/*<div dangerouslySetInnerHTML={createMarkup()} />*/}
                    <CodeWindow changeMode={true} code={'Hello'} />
                </div>
            </div>

        );
    }
}

export default AdminExerciseDetails;