import React, {Component} from 'react';
import {Header} from 'semantic-ui-react';

import './AdminExerciseDetails';
import CodeWindow from '../../components/Modules/CodeWindow';
class AdminExerciseDetails extends Component {

    render() {

        return (
            <div className='container'>
                <div className='codingContainer'>
                    <Header size='large'>Szczegóły zadania</Header>
                    
                    {/*<CodeWindow changeMode={true} code={'Hello'} />*/}
                </div>
            </div>

        );
    }
}

export default AdminExerciseDetails;