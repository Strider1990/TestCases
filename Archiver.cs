// Receiver XML :- <Receivers ListUrl="lists/list_request">

public override void ItemUpdating(SPItemEventProperties properties)
{
	if (properties.ListItem["Status"] == "Closed")
	{
		/* Add item to list_archive when ListItem status is changed to Closed*/
		SPWeb mySite = properties.Web;
		SPListItemCollection archiveListItems = mySite.Lists["list_archive"].Items;
		SPListItem archiveItem = archiveListItems.Add();

		// Not sure if this works, could remove all the code of the bottom if it does.
		// Set properties
		Hashtable ht = properties.ListItem.Properties;
		foreach (DictionaryEntry de in ht)
			archiveItem[de.Key] = de.Value
		/* In case Hashtable doesn't work
		archiveItem["Title"] = properties.ListItem["Title"];
		archiveItem["Request_Date"] = properties.ListItem["Request_Date"];
		archiveItem["Network"] = properties.ListItem["Network"];
		archiveItem["System"] = properties.ListItem["System"];
		archiveItem["Task_To"] = properties.ListItem["Task_To"];
		archiveItem["Project_Name"] = properties.ListItem["Project_Name"];
		archiveItem["Request_Details"] = properties.ListItem["Request_Details"];
		archiveItem["Business_Reason"] = properties.ListItem["Business_Reason"];
		archiveItem["Expire_Date"] = properties.ListItem["Expire_Date"];
		archiveItem["POC"] = properties.ListItem["POC"];
		archiveItem["Status"] = properties.ListItem["Status"];
		archiveItem["Tasker_Remarks"] = properties.ListItem["Tasker_Remarks"];
		archiveItem["Message_To_Taskee"] = properties.ListItem["Message_To_Taskee"];
		archiveItem["Taskee"] = properties.ListItem["Taskee"];
		archiveItem["Message_To_Requestor"] = properties.ListItem["Message_To_Requestor"];
		archiveItem["Approved_By"] = properties.ListItem["Approved_By"];
		archiveItem["Tasked_By"] = properties.ListItem["Tasked_By"];
		archiveItem["Taskee_Remarks"] = properties.ListItem["Taskee_Remarks"];
		archiveItem["Deployment_Plan"] = properties.ListItem["Deployment_Plan"];
		archiveItem["Requestor_Section"] = properties.ListItem["Requestor_Section"];
		archiveItem["Implementation_Date"] = properties.ListItem["Implementation_Date"];
		archiveItem["Is_Message_Read"] = properties.ListItem["Is_Message_Read"];
		archiveItem["CNO"] = properties.ListItem["CNO"];
		archiveItem["Start_Date"] = properties.ListItem["Start_Date"];
		archiveItem["Rejected_Remarks"] = properties.ListItem["Rejected_Remarks"];
		archiveItem.Update();
		*/

		/* Delete relevant list item from list_request */
		SPListItemCollection listItems = properties.List.Items;
		int itemCount = listItems.count;
		for (int i=0; i < itemCount; i++)
		{
			SPListItem item = listItems[i];

			if (properties.ListItem["CNO"] == item["CNO"])
			{
				listItems.Delete(i);
			}
		}
	}
	else
	{
		base.ItemAdded(properties);
	}
}