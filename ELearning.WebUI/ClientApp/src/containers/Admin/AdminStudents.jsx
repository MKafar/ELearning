import React, { Component } from 'react';

import './AdminStudents.scss';
import SearchStudent from '../../components/Modules/SearchStudent';
import DetailList from '../../components/Modules/DeatilList';
import axios from '../../axios';
import { Button, Icon} from 'semantic-ui-react';
import ModalAddStudent  from '../../components/Modules/ModalAddStudent';

class AdminStudents extends Component {

    state = {
        users: [],
        value: '',
        selectedItem: [],
        showSelected: false
    }

    componentDidMount() {
        axios.get('/api/Users/GetAll')
            .then(response => {
                this.setState({ users: response.data.users });
                //console.log(response.data.users);
            });
    }


    valueHandle = (selectedValue) => {
        this.setState({ value: selectedValue });
        this.viewData(selectedValue);
        this.setState({showSelected: true});
    }

    viewData = (selectedId) => {
        //const selectedExercise = this.state.exercises.slice();
        axios.get('/api/Users/Get/' + selectedId)
            .then(response => {
                this.setState({ selectedItem: response.data });
            });
    }

    reverseState = () => {
        this.setState({ showSelected: false });
    }
    
    render() {

        return (
            <div className='adminStudents'>
                <div className='searching'>
                    <div className='content'>
                        <SearchStudent
                            onSelectValue={this.valueHandle} />
                    </div>
                    <Button icon onClick={this.reverseState}><Icon name='delete' /></Button>
                    <ModalAddStudent addHanlde={this.addnewHandler}/>
                </div>

                <div className='studentList'>
                    {this.state.showSelected ?
                        <div>
                            <DetailList
                                key={this.state.selectedItem.id}
                                id={this.state.selectedItem.id}
                                title={this.state.selectedItem.name} />
                        </div>
                        :
                        this.state.users.map((student) => {
                            return <DetailList
                                key={student.id}
                                id={student.id}
                                title={student.name} />
                        })
                    }
                </div>
            </div>
        );
    }
}

export default AdminStudents;