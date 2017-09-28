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
		archiveItem.Update();

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