using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Interfaces;

/// <summary>Ids are required for records.</summary>
public interface IRecord
{
	/// <summary>The record's Identifier.</summary>
	string Id { get; set; }
}
