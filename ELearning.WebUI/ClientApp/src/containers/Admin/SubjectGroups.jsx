import React, { Component } from 'react';
import { Header } from 'semantic-ui-react';
import axios from '../../axios';

import './SubjectGroups.scss';
import ModalAddGroup from '../../components/Modules/ModalAddGroup'
import DetailList from '../../components/Modules/DetailList'

class SubjectGroups extends Component {

    state = {
        exerciseGroups: [],
        selectedSubjectID: null,
        selectedSubjectName: ''
    }

    loadData = () => {
        axios.get('/api/Subjects/GetAllGroupsById/' + this.state.selectedSubjectID)
        .then(response => {
            this.setState({ exerciseGroups: response.data.subjectGroups });
            console.log("Grupy",this.state.exerciseGroups);
        }).catch(error => {
            console.log(error.response);
        });

        axios.get('/api/Subjects/GetById/' + this.state.selectedSubjectID)
        .then(response => {
            this.setState({ selectedSubjectName: response.data.name });
        }).catch(error => {
            console.log(error.response);
        });
        
    }

    componentDidMount = () => {
        this.loadData();
    }
    componentWillMount = () => {

        this.setState({selectedSubjectID: this.props.match.params.subjectID});
    }

    detailsHandler = (exerciseGroupID) => {
        this.props.history.push('/subject/' + this.props.match.params.subjectID + '/' + exerciseGroupID);
    }

    removeHandler = (groupRemoveID) => {
        axios.delete('/api/Groups/Delete/'+ groupRemoveID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć grupy");
            });
    }

    render() {


        return (
            <div className="SubjectGroups">
                <div>
                    <Header size='huge'>
                    {this.state.selectedSubjectName}
                    </Header>

                    <ModalAddGroup selectedSubjectID={this.state.selectedSubjectID} updateData={this.loadData} /> 

                    <div className="groups">

                        {this.state.exerciseGroups.map((group) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={group.groupId}
                                name={group.groupName}
                                text={'Grupa: '} 
                                detailsClicked={()=> this.detailsHandler(group.groupId)}
                                removeClicked={()=>this.removeHandler(group.groupId)}
                                />
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

export default SubjectGroups;