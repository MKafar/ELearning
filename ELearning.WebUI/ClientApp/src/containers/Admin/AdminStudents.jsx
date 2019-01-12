import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';

import './AdminStudents.scss';
import SearchStudent from '../../components/Modules/SearchStudent';
import DetailList from '../../components/Modules/DetailList';
import axios from '../../axios';
import { Button, Icon } from 'semantic-ui-react';
import ModalAddStudent from '../../components/Modules/ModalAddStudent';


class AdminStudents extends Component {

    state = {
        users: [],
        value: '',
        selectedItem: [],
        showSelected: false,
        show: false
    }
    loadData = () => {
        axios.get('/api/Users/GetAll')
            .then(response => {
                this.setState({ users: response.data.users });

            }).catch(error => {
                console.log(error.response);
            });
    }

    componentDidMount() {
        this.loadData();
    }

    valueHandle = (selectedValue) => {
        this.setState({ value: selectedValue });
        this.viewData(selectedValue);
        this.setState({ showSelected: true });
    }

    viewData = (selectedId) => {
        axios.get('/api/Users/GetById/' + selectedId)
            .then(response => {
                console.log(response.data);
                this.setState({ selectedItem: response.data });
            }).catch(error => {
                console.log(error.response)
            });
    }

    reverseState = () => {
        this.setState({ showSelected: false });
    }

    detailsHandler = (detailID) => {
        this.props.history.push('/admin/students/' + detailID);
    }

    removeHandler = (removeID) => {
        console.log('Usuń', removeID);
        axios.delete('/api/Users/Delete/'+ removeID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć studenta mającego przypisaną sekcję.");
            });
    }

    render() {
        

        return (
            <div className='adminStudents'>
                <div className='searching'>
                    <div className='content'>
                        <SearchStudent selectvalue={this.valueHandle} />
                    </div>
                    <Button icon onClick={this.reverseState}><Icon name='delete' /></Button>
                    <div className='addStudentButton'>
                        <ModalAddStudent updateData={this.loadData} addHanlde={this.addnewHandler} />
                    </div>

                </div>

                <div className='studentList'>
                    {this.state.showSelected ?
                        <div>
                            <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={this.state.selectedItem.id}
                                id={this.state.selectedItem.id}
                                title={this.state.selectedItem.name}
                                detailsClicked={()=> this.detailsHandler(this.state.selectedItem.id)}
                                removeClicked={()=>this.removeHandler(this.state.selectedItem.id)}
                                />
                        </div>
                        :
                        this.state.users.map((student) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={student.id}
                                id={student.id}
                                title={student.name}
                                detailsClicked={()=> this.detailsHandler(student.id)}
                                removeClicked={()=>this.removeHandler(student.id)}
                                />
                        })
                    }
                </div>
                
            </div>
        );
    }
}

export default AdminStudents;