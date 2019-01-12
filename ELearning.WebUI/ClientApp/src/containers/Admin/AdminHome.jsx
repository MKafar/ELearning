import React from 'react';
import AssignExerciseModal from '../../components/Modules/AssignExerciseModal';
import { Header } from 'semantic-ui-react';
import axios from '../../axios';

import './AdminHome.scss';


const AdminHome = (props) => (
    <div className='adminhome'>
    {console.log("admin home", props)}
        <Header size="large">Witaj {props.user.username}!</Header>
        <AssignExerciseModal />
    </div>
)

export default AdminHome;
