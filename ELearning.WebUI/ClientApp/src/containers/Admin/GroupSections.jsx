import React, { Component } from 'react';
import { Header } from 'semantic-ui-react';
import axios from '../../axios';

import './GroupSections.scss';
import ModalAddSection from '../../components/Modules/ModalAddSection'
import DetailList from '../../components/Modules/DetailList'

class GroupSections extends Component {

    state = {
        groupSections: [],
        selectedGroupID: null,
        selectedGroupName: ''
    }

    loadData = () => {
        axios.get('/api/Groups/GetAllSectionsById/' + this.state.selectedGroupID)
        .then(response => {
            this.setState({ groupSections: response.data.groupSections });
            console.log("Sekcje",this.state.groupSections);
        }).catch(error => {
            console.log(error.response);
        });

        axios.get('/api/Groups/GetById/' + this.state.selectedGroupID)
        .then(response => {
            this.setState({ selectedGroupName: response.data.name });
        }).catch(error => {
            console.log(error.response);
        });
        
    }

    componentDidMount = () => {
        this.loadData();
    }
    componentWillMount = () => {

        this.setState({selectedGroupID: this.props.match.params.groupSectionsID});
    }

    detailsHandler = (groupSectionID) => {
        this.props.history.push('/subject/' + this.props.match.params.groupSectionsID + '/' + groupSectionID);
    }

    removeHandler = (sectionRemoveID) => {
        axios.delete('/api/Sections/Delete/'+ sectionRemoveID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć sekcji");
            });
    }

    render() {


        return (
            <div className="Sections">
                <div>
                    <Header size='huge'>
                    {this.state.selectedGroupName}
                    </Header>

                    <ModalAddSection selectedGroupID={this.state.selectedGroupID} updateData={this.loadData} /> 

                    <div className="sections">

                        {this.state.groupSections.map((section) => {
                            return <DetailList
                                visibledetail={false}
                                visibledelete={true}
                                key={section.sectionId}
                                studentname={section.userName} 
                                sectionnumber={section.sectionNumber}
                                text={'Sekcja: '} 
                                removeClicked={()=>this.removeHandler(section.sectionId)}
                                />
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

export default GroupSections;