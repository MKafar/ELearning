import React, { Component } from 'react';

import './AdminSubjects.scss';
import SearchSubject from '../../components/Modules/SearchSubject';
import DetailList from '../../components/Modules/DetailList';
import axios from '../../axios';
import { Button, Icon } from 'semantic-ui-react';
import ModalAddSubject from '../../components/Modules/ModalAddSubject';

class AdminSubjects extends Component {

    constructor(props) {
        super(props);
    };

    state = {
        subjects: [],
        value: '',
        selectedItem: [],
        showSelected: false
    }

    loadData = () => {
        axios.get('/api/Subjects/GetAll')
            .then(response => {
                this.setState({ subjects: response.data.subjects })
            });
    }

    componentDidMount() {
        this.loadData();
    }


    valueHandle = (selectedValue) => {
        this.setState({ value: selectedValue });
        this.viewData(selectedValue);
        this.setState({showSelected: true});
    }

    viewData = (selectedId) => {
        //const selectedExercise = this.state.exercises.slice();
        axios.get('/api/Subjects/GetById/' + selectedId)
            .then(response => {
                this.setState({ selectedItem: response.data });
            });
    }

    reverseState = () => {
        this.setState({ showSelected: false });
    }

    removeHandler = (subjectRemoveID) => {
        console.log('Usuń', subjectRemoveID);
        axios.delete('/api/Subjects/Delete/'+ subjectRemoveID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć przedmiotu");
            });
    }

    render() {


        return (
            <div className='adminSubjects'>
                <div className='searching'>
                    <div className='content'>
                        <SearchSubject
                            selectvalue={this.valueHandle} />
                    </div>
                    <Button icon onClick={this.reverseState}><Icon name='delete' /></Button>
                    {/* <Button onClick={this.addnewHandler}>Dodaj zadanie</Button> */}
                    <div className='addSubjectButton'>
                        <ModalAddSubject updateData={this.loadData} addHandle={this.addnewHandler}/>
                    </div>
                    
                </div>

                <div className='subjectsList'>
                    {this.state.showSelected ?
                        <div>
                            <DetailList
                                visibledetail={false}
                                visibledelete={true}
                                id={this.state.selectedItem.id}
                                key={this.state.selectedItem.id}
                                title={this.state.selectedItem.name}
                                removeClicked={()=>this.removeHandler(this.state.selectedItem.id)}
                                 />
                        </div>
                        :
                        this.state.subjects.map((subject) => {
                            return <DetailList
                                visibledetail={false}
                                visibledelete={true}
                                key={subject.id}
                                id={subject.id}
                                title={subject.name}
                                removeClicked={()=>this.removeHandler(subject.id)}
                                
                                 />
                        })
                    }
                </div>
            </div>
        );
    }
}

export default AdminSubjects;