<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/PatentDepartment/Design/DesignDetailsResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<h2 align="center">
						<span style="font-weight:bold; ">
							<xsl:text>Справка за промишлени дизайни</xsl:text>
						</span>
						<span>
							<xsl:text>:</xsl:text>
						</span>
					</h2>
					<xsl:for-each select="n1:DesignDetails">
						<xsl:for-each select="Design">
							<h3 align="center">
								<span>
									<xsl:text>Данни за промишлен дизайн:</xsl:text>
								</span>
							</h3>
							<table align="center" border="1" width="70%">
								<tbody>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Заявителски номер</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="ApplicationNumber">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Дата на заявяване</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="ApplicationDate">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Регистров номер</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="RegistrationNumber">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Регистрова дата</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="RegistrationDate">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Дата на изтичане на срока на закрила</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="ExpiryDate">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Статус (правен статус) </xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="DesignCurrentStatusCode">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Дата на придобиване на текущия правен статус</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="DesignCurrentStatusDate">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Заглавие на дизайна</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="DesignTitle">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Описание - свободен текст</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="DesignDescription">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td>
											<span style="font-weight:bold; ">
												<xsl:text>Тип на дизайна</xsl:text>
											</span>
										</td>
										<td>
											<xsl:for-each select="DesignKind">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
								</tbody>
							</table>
							<p align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Графични изображения на дизайна:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="DesignRepresentationSheetDetails">
								<xsl:for-each select="DesignViews">
									<xsl:for-each select="ViewBinary">
										<div align="center">
											<img>
												<xsl:attribute name="src">
													<xsl:if test="substring(string(concat(&quot;data:image/png;base64,&quot;, string(.))), 2, 1) = ':'">
														<xsl:text>file:///</xsl:text>
													</xsl:if>
													<xsl:value-of select="translate(string(concat(&quot;data:image/png;base64,&quot;, string(.))), '&#x5c;', '/')"/>
												</xsl:attribute>
												<xsl:attribute name="alt"/>
											</img>
										</div>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<p align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Продуктови описания съгласно международна класификация:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="IndicationProductDetails">
								<table align="center" border="1" width="70%">
									<thead>
										<tr>
											<th align="center">
												<span>
													<xsl:text>Koд според международната класификация</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Текстово описание </xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="IndicationProduct">
											<tr>
												<td>
													<xsl:for-each select="ClassNumber">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="ProductDescription">
														<div>
															<xsl:apply-templates/>
														</div>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:for-each>
							<p align="center">
								<span style="font-size:large; font-weight:bold; ">
									<xsl:text>Kонвенционен приоритет:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="PriorityDetails">
								<table align="center" border="1" width="70%">
									<thead>
										<tr>
											<th align="center">
												<span>
													<xsl:text>Държава на приоритет</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Номер на приоритет</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Дата</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="Priority">
											<tr>
												<td>
													<xsl:for-each select="PriorityCountryCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="PriorityNumber">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="PriorityDate">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:for-each>
							<br/>
							<p style="font-size:large; " align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Изложбен приоритет</xsl:text>
								</span>
								<span>
									<xsl:text>:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="ExhibitionPriorityDetails">
								<table align="center" border="1" width="70%">
									<thead>
										<tr>
											<th align="center">
												<span>
													<xsl:text>Държава на изложбен приоритет</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Име на град</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Име на изложба</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Дата на изложба</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Коментар</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="ExhibitionPriority">
											<tr>
												<td>
													<xsl:for-each select="ExhibitionCountryCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="ExhibitionCityName">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="ExhibitionName">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="ExhibitionDate">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="Comment">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:for-each>
							<br/>
							<p style="font-size:large; " align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Данни за публикации в бюлетина на Патентно ведомство</xsl:text>
								</span>
								<span>
									<xsl:text>:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="PublicationDetails">
								<table align="center" border="1" width="70%">
									<thead>
										<tr>
											<th align="center">
												<span>
													<xsl:text>Номер на бюлетин</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Раздел в бюлетина</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Подраздел в бюлетина</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Дата на публикация</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="Publication">
											<tr>
												<td>
													<xsl:for-each select="PublicationIdentifier">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="PublicationSection">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="PublicationSubsection">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="PublicationDate">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:for-each>
							<br/>
							<p style="font-size:large; " align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Данни за заявителите</xsl:text>
								</span>
								<span>
									<xsl:text>:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="ApplicantDetails">
								<table align="center" border="1" width="70%">
									<thead>
										<tr>
											<th align="center">
												<span>
													<xsl:text>Вътрешно-системен идентификатор </xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Националност (код)</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="Applicant">
											<tr>
												<td>
													<xsl:for-each select="ApplicantIdentifier">
														<div>
															<xsl:apply-templates/>
														</div>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="ApplicantNationalityCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:for-each>
							<xsl:for-each select="ApplicantDetails">
								<xsl:for-each select="Applicant">
									<xsl:for-each select="ApplicantAddressBook">
										<xsl:for-each select="FormattedNameAddress">
											<xsl:for-each select="Name">
												<table align="center" border="1" width="70%">
													<thead>
														<tr>
															<th align="center">
																<span>
																	<xsl:text>Префикс</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Име</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Презиме</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Фамилия</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Втора фамилия</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Организация</xsl:text>
																</span>
															</th>
														</tr>
													</thead>
													<tbody>
														<xsl:for-each select="FormattedName">
															<tr>
																<td>
																	<xsl:for-each select="NamePrefix">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="FirstName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="MiddleName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="LastName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="SecondLastName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="OrganizationName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<br/>
							<p align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Адрес:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="ApplicantDetails">
								<xsl:for-each select="Applicant">
									<xsl:for-each select="ApplicantAddressBook">
										<xsl:for-each select="FormattedNameAddress">
											<xsl:for-each select="Address">
												<table align="center" border="1" width="70%">
													<thead>
														<tr>
															<th align="center">
																<span>
																	<xsl:text>Улица</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Град</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Държава</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Щат</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Пощенски код</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Двубуквен код на държава</xsl:text>
																</span>
															</th>
														</tr>
													</thead>
													<tbody>
														<xsl:for-each select="FormattedAddress">
															<tr>
																<td>
																	<xsl:for-each select="AddressStreet">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressCity">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressCounty">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressState">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressPostcode">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="FormattedAddressCountryCode">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<br/>
							<p align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Данни за контакт: </xsl:text>
								</span>
							</p>
							<xsl:for-each select="ApplicantDetails">
								<xsl:for-each select="Applicant">
									<xsl:for-each select="ApplicantAddressBook">
										<xsl:for-each select="ContactInformationDetails">
											<table align="center" border="1" width="70%">
												<thead>
													<tr>
														<th align="center">
															<span>
																<xsl:text>Телефон</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>Факс</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>E-mail</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>Уебсайт</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>Друг електронен адрес</xsl:text>
															</span>
														</th>
													</tr>
												</thead>
												<tbody>
													<tr>
														<td>
															<xsl:for-each select="Phone">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="Fax">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="Email">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="URL">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="OtherElectronicAddress">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<br/>
							<p style="font-size:large; " align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Данни за представителите по индустриална собственост (ПИС)</xsl:text>
								</span>
								<span>
									<xsl:text>:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="RepresentativeDetails">
								<table align="center" border="1" width="70%">
									<thead>
										<tr>
											<th align="center">
												<span>
													<xsl:text>Идентификатор на ПИС</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Националност</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Тип на ПИС (физическо/юридическо лице)</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="Representative">
											<tr>
												<td>
													<xsl:for-each select="RepresentativeIdentifier">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="RepresentativeNationalityCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="RepresentativeLegalEntity">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:for-each>
							<xsl:for-each select="RepresentativeDetails">
								<xsl:for-each select="Representative">
									<xsl:for-each select="RepresentativeAddressBook">
										<xsl:for-each select="FormattedNameAddress">
											<xsl:for-each select="Name">
												<table align="center" border="1" width="70%">
													<thead>
														<tr>
															<th align="center">
																<span>
																	<xsl:text>Префикс</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Име</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Презиме</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Фамилия</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Втора фамилия</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Име на организация</xsl:text>
																</span>
															</th>
														</tr>
													</thead>
													<tbody>
														<xsl:for-each select="FormattedName">
															<tr>
																<td>
																	<xsl:for-each select="NamePrefix">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="FirstName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="MiddleName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="LastName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="SecondLastName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="OrganizationName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<br/>
							<p style="font-size:larger; " align="center">
								<span style="font-weight:bold; ">
									<xsl:text>Адрес:</xsl:text>
								</span>
							</p>
							<xsl:for-each select="RepresentativeDetails">
								<xsl:for-each select="Representative">
									<xsl:for-each select="RepresentativeAddressBook">
										<xsl:for-each select="FormattedNameAddress">
											<xsl:for-each select="Address">
												<table align="center" border="1" width="70%">
													<thead>
														<tr>
															<th align="center">
																<span>
																	<xsl:text>Улица</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Град</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Държава</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Щат</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Пощенски код</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Двубуквен код на държава</xsl:text>
																</span>
															</th>
														</tr>
													</thead>
													<tbody>
														<xsl:for-each select="FormattedAddress">
															<tr>
																<td>
																	<xsl:for-each select="AddressStreet">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressCity">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressCounty">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressState">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressPostcode">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="FormattedAddressCountryCode">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<br/>
							<p style="font-weight:bold; " align="center">
								<span>
									<xsl:text>Данни за контакт: </xsl:text>
								</span>
							</p>
							<xsl:for-each select="RepresentativeDetails">
								<xsl:for-each select="Representative">
									<xsl:for-each select="RepresentativeAddressBook">
										<xsl:for-each select="ContactInformationDetails">
											<table align="center" border="1" width="70%">
												<thead>
													<tr>
														<th align="center">
															<span>
																<xsl:text>Телефон</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>Факс</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>E-mail</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>Уебсайт</xsl:text>
															</span>
														</th>
														<th align="center">
															<span>
																<xsl:text>Друг електронен адрес</xsl:text>
															</span>
														</th>
													</tr>
												</thead>
												<tbody>
													<tr>
														<td>
															<xsl:for-each select="Phone">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="Fax">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="Email">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="URL">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="OtherElectronicAddress">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<xsl:for-each select="DesignerDetails">
								<xsl:for-each select="Designer">
									<p style="font-size:large; " align="center">
										<span style="font-weight:bold; ">
											<xsl:text>Данни за дизайнер/и</xsl:text>
										</span>
										<span>
											<xsl:text>:</xsl:text>
										</span>
									</p>
									<table align="center" border="1" width="70%">
										<thead>
											<tr>
												<th align="center">
													<span>
														<xsl:text>Националност</xsl:text>
													</span>
												</th>
												<th align="center">
													<span>
														<xsl:text>Тип на дизайнер (физическо/юридическо лице)</xsl:text>
													</span>
												</th>
											</tr>
										</thead>
										<tbody>
											<tr>
												<td>
													<xsl:for-each select="DesignerNationalityCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="DesignerLegalEntity">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</tbody>
									</table>
									<xsl:for-each select="DesignerAddressBook">
										<xsl:for-each select="FormattedNameAddress">
											<xsl:for-each select="Name">
												<table align="center" border="1" width="70%">
													<thead>
														<tr>
															<th align="center">
																<span>
																	<xsl:text>Префикс</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Име</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Презиме</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Фамилия</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Втора фамилия</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Име на организация</xsl:text>
																</span>
															</th>
														</tr>
													</thead>
													<tbody>
														<xsl:for-each select="FormattedName">
															<tr>
																<td>
																	<xsl:for-each select="NamePrefix">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="FirstName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="MiddleName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="LastName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="SecondLastName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="OrganizationName">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
									<p style="font-size:large; " align="center">
										<span style="font-weight:bold; ">
											<xsl:text>Адрес:</xsl:text>
										</span>
									</p>
									<xsl:for-each select="DesignerAddressBook">
										<xsl:for-each select="FormattedNameAddress">
											<xsl:for-each select="Address">
												<table align="center" border="1" width="70%">
													<thead>
														<tr>
															<th align="center">
																<span>
																	<xsl:text>Улица</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Град</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Държава</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Щат</xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Пощенски код </xsl:text>
																</span>
															</th>
															<th align="center">
																<span>
																	<xsl:text>Двубуквен код на държава</xsl:text>
																</span>
															</th>
														</tr>
													</thead>
													<tbody>
														<xsl:for-each select="FormattedAddress">
															<tr>
																<td>
																	<xsl:for-each select="AddressStreet">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressCity">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressCounty">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressState">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="AddressPostcode">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="FormattedAddressCountryCode">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
									<p align="center">
										<span style="font-weight:bold; ">
											<xsl:text>Данни за контакт: </xsl:text>
										</span>
									</p>
									<xsl:for-each select="DesignerAddressBook">
										<xsl:for-each select="ContactInformationDetails">
											<table align="center" border="1" width="70%">
												<thead>
													<tr>
														<th>
															<span>
																<xsl:text>Телефон</xsl:text>
															</span>
														</th>
														<th>
															<span>
																<xsl:text>Факс</xsl:text>
															</span>
														</th>
														<th>
															<span>
																<xsl:text>E-mail</xsl:text>
															</span>
														</th>
														<th>
															<span>
																<xsl:text>Уебсайт</xsl:text>
															</span>
														</th>
														<th>
															<span>
																<xsl:text> Друг електронен адрес</xsl:text>
															</span>
														</th>
													</tr>
												</thead>
												<tbody>
													<tr>
														<td>
															<xsl:for-each select="Phone">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="Fax">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="Email">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="URL">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="OtherElectronicAddress">
																<div>
																	<xsl:apply-templates/>
																</div>
															</xsl:for-each>
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:for-each>
					</xsl:for-each>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>