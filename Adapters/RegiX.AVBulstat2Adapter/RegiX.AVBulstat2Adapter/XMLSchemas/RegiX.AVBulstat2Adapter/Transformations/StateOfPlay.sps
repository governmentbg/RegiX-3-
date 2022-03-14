<?xml version="1.0" encoding="UTF-8"?>
<structure version="20" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" html-outputextent="Complete" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="E" uri="http://www.bulstat.bg/Entry"/>
			<nspair prefix="PROP0" uri="http://www.bulstat.bg/SubjectPropLifeTime"/>
			<nspair prefix="PROP1" uri="http://www.bulstat.bg/SubjectPropState"/>
			<nspair prefix="PROP10" uri="http://www.bulstat.bg/SubjectPropActivityDate"/>
			<nspair prefix="PROP11" uri="http://www.bulstat.bg/SubjectPropProfession"/>
			<nspair prefix="PROP12" uri="http://www.bulstat.bg/SubjectPropCollectiveBody"/>
			<nspair prefix="PROP2" uri="http://www.bulstat.bg/SubjectPropScopeOfActivity"/>
			<nspair prefix="PROP3" uri="http://www.bulstat.bg/SubjectPropActivityKID2008"/>
			<nspair prefix="PROP4" uri="http://www.bulstat.bg/SubjectPropActivityKID2003"/>
			<nspair prefix="PROP5" uri="http://www.bulstat.bg/SubjectPropInstallments"/>
			<nspair prefix="PROP6" uri="http://www.bulstat.bg/SubjectPropRepresentationType"/>
			<nspair prefix="PROP7" uri="http://www.bulstat.bg/SubjectPropFundingSource"/>
			<nspair prefix="PROP8" uri="http://www.bulstat.bg/SubjectPropOwnershipForm"/>
			<nspair prefix="PROP9" uri="http://www.bulstat.bg/SubjectPropAccountingRecordForm"/>
			<nspair prefix="REL0" uri="http://www.bulstat.bg/SubjectRelPartner"/>
			<nspair prefix="REL1" uri="http://www.bulstat.bg/SubjectRelManager"/>
			<nspair prefix="REL2" uri="http://www.bulstat.bg/SubjectRelBelonging"/>
			<nspair prefix="REL3" uri="http://www.bulstat.bg/SubjectRelAssignee"/>
			<nspair prefix="REL4" uri="http://www.bulstat.bg/SubjectRelCollectiveBodyMember"/>
			<nspair prefix="T17" uri="http://www.bulstat.bg/Document"/>
			<nspair prefix="T171" uri="http://www.bulstat.bg/IdentificationDoc"/>
			<nspair prefix="T18" uri="http://www.bulstat.bg/Event"/>
			<nspair prefix="T22" uri="http://www.bulstat.bg/LegalEntity"/>
			<nspair prefix="T23" uri="http://www.bulstat.bg/NaturalPerson"/>
			<nspair prefix="T25" uri="http://www.bulstat.bg/Subject"/>
			<nspair prefix="T251" uri="http://www.bulstat.bg/UIC"/>
			<nspair prefix="T27" uri="http://www.bulstat.bg/Case"/>
			<nspair prefix="T28" uri="http://www.bulstat.bg/Communication"/>
			<nspair prefix="T3" uri="http://www.bulstat.bg/NomenclatureEntry"/>
			<nspair prefix="T40" uri="http://www.bulstat.bg/SubscriptionElement"/>
			<nspair prefix="T8" uri="http://www.bulstat.bg/Address"/>
			<nspair prefix="tns" uri="http://www.bulstat.bg/StateOfPlay"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.AVBulstat2Adapter\XMLSchemas\StateOfPlay.xsd" workingxmlfile="empty.xml"/>
		</schemasources>
	</schemasources>
	<modules/>
	<flags>
		<scripts/>
		<mainparts/>
		<globalparts/>
		<designfragments/>
		<pagelayouts/>
		<xpath-functions/>
	</flags>
	<scripts>
		<script language="javascript"/>
	</scripts>
	<script-project>
		<Project version="4" app="AuthenticView"/>
	</script-project>
	<importedxslt/>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate subtype="main" match="/">
				<document-properties/>
				<children>
					<documentsection>
						<properties columncount="1" columngap="0.50in" headerfooterheight="fixed" pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="auto" pagestart="next" paperheight="11in" papermarginbottom="0.79in" papermarginfooter="0.30in" papermarginheader="0.30in" papermarginleft="0.60in" papermarginright="0.60in" papermargintop="0.79in" paperwidth="8.50in"/>
						<watermark>
							<image transparency="50" fill-page="1" center-if-not-fill="1"/>
							<text transparency="50"/>
						</watermark>
					</documentsection>
					<template subtype="source" match="XML">
						<children>
							<paragraph paragraphtag="h4">
								<styles border-left-color="gray" border-left-style="solid" padding-left="10px"/>
								<children>
									<text fixtext="РЕПУБЛИКА БЪЛГАРИЯ"/>
									<newline/>
									<text fixtext="Агенция по вписванията"/>
								</children>
							</paragraph>
							<paragraph paragraphtag="h2">
								<properties align="left"/>
								<children>
									<text fixtext="Справка за актуално състояние на субект на БУЛСТАТ"/>
								</children>
							</paragraph>
							<condition>
								<children>
									<conditionbranch xpath="count(tns:StateOfPlay/*)&gt;0">
										<children>
											<template subtype="element" match="tns:StateOfPlay">
												<children>
													<template subtype="element" match="tns:Subject">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Субект на БУЛСТАТ">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<calltemplate subtype="named" match="Subject">
																<parameters/>
															</calltemplate>
														</children>
														<variables/>
													</template>
													<newline/>
													<template subtype="element" match="tns:Event">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Последно регистрирано събитие за субекта">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																							<template subtype="element" match="T18:EntryType">
																								<children>
																									<newline/>
																									<content subtype="regular"/>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="T18:EventDate">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Дата:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="anySimpleType"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T18:EventType">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Вид:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T18:LegalBase">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Правно основание:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T18:Case">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																					<tgridcol>
																						<styles width="100px"/>
																					</tgridcol>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Преписка:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T27:Court">
																										<children>
																											<template subtype="element" match="T3:Code">
																												<children>
																													<text fixtext="Код на съд: "/>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="string"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T27:Year">
																										<children>
																											<text fixtext=", година: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="int"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T27:Number">
																										<children>
																											<text fixtext=", номер: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T27:Batch">
																										<children>
																											<text fixtext=" "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T27:Register">
																										<children>
																											<text fixtext=", регистър: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="int"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T27:Chapter">
																										<children>
																											<text fixtext=", глава: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T27:PageNumber">
																										<children>
																											<text fixtext=", стр.: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="int"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<styles text-align="right"/>
																								<children>
																									<template subtype="element" match="E:EntryTime">
																										<children>
																											<content subtype="regular">
																												<styles font-size="x-small" font-style="italic"/>
																												<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T18:Document">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																					<tgridcol>
																						<styles width="100px"/>
																					</tgridcol>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Документ:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T17:DocumentType">
																										<children>
																											<template subtype="element" match="T3:Code">
																												<children>
																													<text fixtext="Вид документ (заявление, решение и т.н): "/>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="string"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T17:DocumentNumber">
																										<children>
																											<text fixtext=", номер: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T17:DocumentDate">
																										<children>
																											<text fixtext=", дата на документа: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" string="YYYY.MM.DD" datatype="anySimpleType"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T17:ValidFromDate">
																										<children>
																											<text fixtext=", дата на която влиза в сила: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" string="YYYY.MM.DD" datatype="anySimpleType"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T17:DocumentName">
																										<children>
																											<text fixtext=", наименование: "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<styles text-align="right"/>
																								<children>
																									<template subtype="element" match="E:EntryTime">
																										<children>
																											<content subtype="regular">
																												<styles font-size="x-small" font-style="italic"/>
																												<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																	<template subtype="element" match="T17:AuthorName">
																		<children>
																			<text fixtext="Име на автора:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="T17:Author">
																		<children>
																			<paragraph>
																				<styles background-color="silver" font-weight="bold"/>
																				<children>
																					<text fixtext="Автор"/>
																				</children>
																			</paragraph>
																			<calltemplate subtype="named" match="Subject">
																				<parameters/>
																			</calltemplate>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:RepresentationType">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Начин на представляване">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP6:Type">
																<children>
																	<template subtype="element" match="T3:Code">
																		<children>
																			<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																				<properties border="0" width="100%"/>
																				<children>
																					<tgridbody-cols>
																						<children>
																							<tgridcol>
																								<styles width="250px"/>
																							</tgridcol>
																							<tgridcol/>
																						</children>
																					</tgridbody-cols>
																					<tgridbody-rows>
																						<children>
																							<tgridrow>
																								<children>
																									<tgridcell>
																										<properties valign="top"/>
																										<children>
																											<paragraph>
																												<styles font-weight="bold"/>
																												<children>
																													<text fixtext="Тип:"/>
																												</children>
																											</paragraph>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<properties valign="top"/>
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																									</tgridcell>
																								</children>
																							</tgridrow>
																						</children>
																					</tgridbody-rows>
																				</children>
																				<wizard-data-repeat>
																					<children/>
																				</wizard-data-repeat>
																				<wizard-data-rows>
																					<children/>
																				</wizard-data-rows>
																				<wizard-data-columns>
																					<children/>
																				</wizard-data-columns>
																			</tgrid>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="PROP6:Description">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Описание:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="string"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:ScopeOfActivity">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Предмет на дейност">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP2:Description">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Описание:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="string"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:MainActivity2003">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Основна дейност по КИД2003">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP4:NKID2003">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Описание:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:MainActivity2008">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Основна дейност по КИД2008">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP3:KID2008">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Описание:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="string-length(tns:Installments)&gt;0">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<properties bgcolor="#e1e1e1" valign="top"/>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph paragraphtag="h3">
																										<styles text-decoration="underline"/>
																										<children>
																											<text fixtext="Вноски">
																												<styles font-size="24px"/>
																											</text>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="tns:Installments">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP5:Count">
																								<children>
																									<text fixtext="Брой:">
																										<styles font-weight="bold"/>
																									</text>
																									<text fixtext=" "/>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="int"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP5:Amount">
																								<children>
																									<text fixtext="Стойност:">
																										<styles font-weight="bold"/>
																									</text>
																									<text fixtext=" "/>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="decimal"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:LifeTime">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Срок на съществуване">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP0:Date">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Дата:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="anySimpleType"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="PROP0:Description">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Описание:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="string"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:AccountingRecordForm">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Форма на счетоводно записване">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph>
																								<styles font-weight="bold"/>
																								<children>
																									<text fixtext="Код:"/>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP9:Form">
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="string-length(tns:OwnershipForms)&gt;0">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<properties bgcolor="#e1e1e1" valign="top"/>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph paragraphtag="h3">
																										<styles text-decoration="underline"/>
																										<children>
																											<text fixtext="Форма на собственост">
																												<styles font-size="24px"/>
																											</text>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="tns:OwnershipForms">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP8:Form">
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<text fixtext="Код: ">
																												<styles font-weight="bold"/>
																											</text>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP8:Percent">
																								<children>
																									<text fixtext="Процент: ">
																										<styles font-weight="bold"/>
																									</text>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="decimal"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="string-length(tns:FundingSources)&gt;0">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<properties bgcolor="#e1e1e1" valign="top"/>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph paragraphtag="h3">
																										<styles text-decoration="underline"/>
																										<children>
																											<text fixtext="Източници на финансиране">
																												<styles font-size="24px"/>
																											</text>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="tns:FundingSources">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP7:Source">
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<text fixtext="Код: ">
																												<styles font-weight="bold"/>
																											</text>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP7:Percent">
																								<children>
																									<text fixtext="Процент: ">
																										<styles font-weight="bold"/>
																									</text>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="decimal"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:State">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Състояние на субект">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP1:State">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Код:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="tns:ActivityDate">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Дата на започване/ спиране/ възобновяване на дейността">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP10:Type">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Код:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="PROP10:Date">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Дата:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="anySimpleType"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="string-length(tns:CollectiveBodies)&gt;0">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<properties bgcolor="#e1e1e1" valign="top"/>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph paragraphtag="h3">
																										<styles text-decoration="underline"/>
																										<children>
																											<text fixtext="Колективни органи">
																												<styles font-size="24px"/>
																											</text>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="tns:CollectiveBodies">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#d2d2d2"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP12:Type">
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<paragraph paragraphtag="h4">
																												<children>
																													<text fixtext="Вид колективен орган: "/>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="string"/>
																													</content>
																												</children>
																											</paragraph>
																										</children>
																										<variables/>
																									</template>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP12:Members">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
																					<tgridcol>
																						<styles width="100px"/>
																					</tgridcol>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<properties bgcolor="#d2d2d2"/>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<children>
																											<text fixtext="Член на колективен орган">
																												<styles font-weight="bold"/>
																											</text>
																										</children>
																									</paragraph>
																									<template subtype="element" match="REL4:Position">
																										<children>
																											<template subtype="element" match="T3:Code">
																												<children>
																													<text fixtext="Код на длъжност в управлението: "/>
																													<content subtype="regular">
																														<format basic-type="xsd" datatype="string"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<styles text-align="right"/>
																								<children>
																									<template subtype="element" match="E:EntryTime">
																										<children>
																											<content subtype="regular">
																												<styles font-size="x-small" font-style="italic"/>
																												<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																									<template subtype="element" match="T40:OperationType">
																										<children>
																											<paragraph>
																												<children>
																													<text fixtext="(">
																														<styles font-size="x-small" font-style="italic"/>
																													</text>
																													<content subtype="regular">
																														<styles font-size="x-small" font-style="italic"/>
																														<format basic-type="xsd" datatype="string"/>
																													</content>
																													<text fixtext=")">
																														<styles font-size="x-small" font-style="italic"/>
																													</text>
																												</children>
																											</paragraph>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																	<template subtype="element" match="REL4:RelatedSubject">
																		<children>
																			<paragraph>
																				<styles background-color="silver" font-weight="bold"/>
																				<children>
																					<text fixtext="Колективни органи/Член на колективен орган/Субект"/>
																				</children>
																			</paragraph>
																			<calltemplate subtype="named" match="Subject">
																				<parameters/>
																			</calltemplate>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="REL4:RepresentedSubjects">
																		<children>
																			<paragraph>
																				<styles background-color="silver" font-weight="bold"/>
																				<children>
																					<text fixtext="Колективни органи/Член на колективен орган/Представляван субект"/>
																				</children>
																			</paragraph>
																			<calltemplate subtype="named" match="Subject">
																				<parameters/>
																			</calltemplate>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<newline/>
													<template subtype="element" match="tns:AdditionalActivities2008">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<properties bgcolor="#e1e1e1" valign="top"/>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph paragraphtag="h3">
																								<styles text-decoration="underline"/>
																								<children>
																									<text fixtext="Допълнителни дейности по КИД2008">
																										<styles font-size="24px"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<styles text-align="right"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
															<template subtype="element" match="PROP3:KID2008">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<styles font-weight="bold"/>
																										<children>
																											<text fixtext="Код:"/>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
															<newline/>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="string-length(tns:Professions)&gt;0">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<properties bgcolor="#e1e1e1" valign="top"/>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph paragraphtag="h3">
																										<styles text-decoration="underline"/>
																										<children>
																											<text fixtext="Професии">
																												<styles font-size="24px"/>
																											</text>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
															</conditionbranch>
														</children>
													</condition>
													<template subtype="element" match="tns:Professions">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="PROP11:Profession">
																								<children>
																									<template subtype="element" match="T3:Code">
																										<children>
																											<text fixtext="Код:">
																												<styles font-weight="bold"/>
																											</text>
																											<text fixtext=" "/>
																											<content subtype="regular">
																												<format basic-type="xsd" datatype="string"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
													<condition>
														<children>
															<conditionbranch xpath="string-length(tns:Managers) + string-length(tns:Partners) + string-length(tns:Assignee) + string-length(tns:Belonging)&gt;0">
																<children>
																	<paragraph paragraphtag="h3">
																		<styles background-color="#b3b3b3"/>
																		<children>
																			<text fixtext="Връзки на субекта на БУЛСТАТ с други субекти"/>
																		</children>
																	</paragraph>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length(tns:Managers)&gt;0">
																				<children>
																					<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																						<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																						<children>
																							<tgridbody-cols>
																								<children>
																									<tgridcol/>
																								</children>
																							</tgridbody-cols>
																							<tgridbody-rows>
																								<children>
																									<tgridrow>
																										<properties bgcolor="#e1e1e1" valign="top"/>
																										<children>
																											<tgridcell>
																												<properties valign="top"/>
																												<children>
																													<paragraph paragraphtag="h3">
																														<styles text-decoration="underline"/>
																														<children>
																															<text fixtext="Управители">
																																<styles font-size="24px"/>
																															</text>
																														</children>
																													</paragraph>
																												</children>
																											</tgridcell>
																										</children>
																									</tgridrow>
																								</children>
																							</tgridbody-rows>
																						</children>
																						<wizard-data-repeat>
																							<children/>
																						</wizard-data-repeat>
																						<wizard-data-rows>
																							<children/>
																						</wizard-data-rows>
																						<wizard-data-columns>
																							<children/>
																						</wizard-data-columns>
																					</tgrid>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="tns:Managers">
																		<children>
																			<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																				<properties border="0" width="100%"/>
																				<children>
																					<tgridbody-cols>
																						<children>
																							<tgridcol/>
																							<tgridcol>
																								<styles width="100px"/>
																							</tgridcol>
																						</children>
																					</tgridbody-cols>
																					<tgridbody-rows>
																						<children>
																							<tgridrow>
																								<properties bgcolor="#d2d2d2"/>
																								<children>
																									<tgridcell>
																										<properties valign="top"/>
																										<children>
																											<paragraph>
																												<styles font-weight="bold"/>
																												<children>
																													<text fixtext="Управител"/>
																												</children>
																											</paragraph>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<properties valign="top"/>
																										<styles text-align="right"/>
																										<children>
																											<template subtype="element" match="E:EntryTime">
																												<children>
																													<content subtype="regular">
																														<styles font-size="x-small" font-style="italic"/>
																														<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																								</children>
																							</tgridrow>
																						</children>
																					</tgridbody-rows>
																				</children>
																				<wizard-data-repeat>
																					<children/>
																				</wizard-data-repeat>
																				<wizard-data-rows>
																					<children/>
																				</wizard-data-rows>
																				<wizard-data-columns>
																					<children/>
																				</wizard-data-columns>
																			</tgrid>
																			<template subtype="element" match="REL1:Position">
																				<children>
																					<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																						<properties border="0" width="100%"/>
																						<children>
																							<tgridbody-cols>
																								<children>
																									<tgridcol>
																										<styles width="250px"/>
																									</tgridcol>
																									<tgridcol/>
																								</children>
																							</tgridbody-cols>
																							<tgridbody-rows>
																								<children>
																									<tgridrow>
																										<children>
																											<tgridcell>
																												<properties valign="top"/>
																												<children>
																													<paragraph>
																														<styles font-weight="bold"/>
																														<children>
																															<text fixtext="Позиция:"/>
																														</children>
																													</paragraph>
																												</children>
																											</tgridcell>
																											<tgridcell>
																												<properties valign="top"/>
																												<children>
																													<template subtype="element" match="T3:Code">
																														<children>
																															<content subtype="regular">
																																<format basic-type="xsd" datatype="string"/>
																															</content>
																														</children>
																														<variables/>
																													</template>
																												</children>
																											</tgridcell>
																										</children>
																									</tgridrow>
																								</children>
																							</tgridbody-rows>
																						</children>
																						<wizard-data-repeat>
																							<children/>
																						</wizard-data-repeat>
																						<wizard-data-rows>
																							<children/>
																						</wizard-data-rows>
																						<wizard-data-columns>
																							<children/>
																						</wizard-data-columns>
																					</tgrid>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="REL1:RelatedSubject">
																				<children>
																					<calltemplate subtype="named" match="Subject">
																						<parameters/>
																					</calltemplate>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="REL1:RepresentedSubjects">
																				<children>
																					<paragraph>
																						<styles background-color="silver" font-weight="bold"/>
																						<children>
																							<text fixtext="Субект, който представлява"/>
																						</children>
																					</paragraph>
																					<calltemplate subtype="named" match="Subject">
																						<parameters/>
																					</calltemplate>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length(tns:Partners)&gt;0">
																				<children>
																					<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																						<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																						<children>
																							<tgridbody-cols>
																								<children>
																									<tgridcol/>
																								</children>
																							</tgridbody-cols>
																							<tgridbody-rows>
																								<children>
																									<tgridrow>
																										<properties bgcolor="#e1e1e1" valign="top"/>
																										<children>
																											<tgridcell>
																												<properties valign="top"/>
																												<children>
																													<paragraph paragraphtag="h3">
																														<styles text-decoration="underline"/>
																														<children>
																															<text fixtext="Собственици/ съдружници">
																																<styles font-size="24px"/>
																															</text>
																														</children>
																													</paragraph>
																												</children>
																											</tgridcell>
																										</children>
																									</tgridrow>
																								</children>
																							</tgridbody-rows>
																						</children>
																						<wizard-data-repeat>
																							<children/>
																						</wizard-data-repeat>
																						<wizard-data-rows>
																							<children/>
																						</wizard-data-rows>
																						<wizard-data-columns>
																							<children/>
																						</wizard-data-columns>
																					</tgrid>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="tns:Partners">
																		<children>
																			<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																				<properties border="0" width="100%"/>
																				<children>
																					<tgridbody-cols>
																						<children>
																							<tgridcol/>
																							<tgridcol>
																								<styles width="100px"/>
																							</tgridcol>
																						</children>
																					</tgridbody-cols>
																					<tgridbody-rows>
																						<children>
																							<tgridrow>
																								<properties bgcolor="#d2d2d2"/>
																								<children>
																									<tgridcell>
																										<properties valign="top"/>
																										<children>
																											<paragraph>
																												<styles font-weight="bold"/>
																												<children>
																													<text fixtext="Съдружник"/>
																												</children>
																											</paragraph>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<properties valign="top"/>
																										<styles text-align="right"/>
																										<children>
																											<template subtype="element" match="E:EntryTime">
																												<children>
																													<content subtype="regular">
																														<styles font-size="x-small" font-style="italic"/>
																														<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																											<template subtype="element" match="T40:OperationType">
																												<children>
																													<paragraph>
																														<children>
																															<text fixtext="(">
																																<styles font-size="x-small" font-style="italic"/>
																															</text>
																															<content subtype="regular">
																																<styles font-size="x-small" font-style="italic"/>
																																<format basic-type="xsd" datatype="string"/>
																															</content>
																															<text fixtext=")">
																																<styles font-size="x-small" font-style="italic"/>
																															</text>
																														</children>
																													</paragraph>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																								</children>
																							</tgridrow>
																						</children>
																					</tgridbody-rows>
																				</children>
																				<wizard-data-repeat>
																					<children/>
																				</wizard-data-repeat>
																				<wizard-data-rows>
																					<children/>
																				</wizard-data-rows>
																				<wizard-data-columns>
																					<children/>
																				</wizard-data-columns>
																			</tgrid>
																			<template subtype="element" match="REL0:Role">
																				<children>
																					<text fixtext="Роля в собствеността: ">
																						<styles font-weight="bold"/>
																					</text>
																					<template subtype="element" match="T3:Code">
																						<children>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="REL0:Percent">
																				<children>
																					<newline/>
																					<text fixtext="Процент разпределение на собств. без капитал: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																						<format basic-type="xsd" datatype="decimal"/>
																					</content>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="REL0:Amount">
																				<children>
																					<newline/>
																					<text fixtext="Дял в собствеността: ">
																						<styles font-weight="bold"/>
																					</text>
																					<content subtype="regular">
																						<styles font-weight="bold"/>
																						<format basic-type="xsd" datatype="decimal"/>
																					</content>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="REL0:RelatedSubject">
																				<children>
																					<calltemplate subtype="named" match="Subject">
																						<parameters/>
																					</calltemplate>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length(tns:Assignee)&gt;0">
																				<children>
																					<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																						<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																						<children>
																							<tgridbody-cols>
																								<children>
																									<tgridcol/>
																								</children>
																							</tgridbody-cols>
																							<tgridbody-rows>
																								<children>
																									<tgridrow>
																										<properties bgcolor="#e1e1e1" valign="top"/>
																										<children>
																											<tgridcell>
																												<properties valign="top"/>
																												<children>
																													<paragraph paragraphtag="h3">
																														<styles text-decoration="underline"/>
																														<children>
																															<text fixtext="Правоприемство">
																																<styles font-size="24px"/>
																															</text>
																														</children>
																													</paragraph>
																												</children>
																											</tgridcell>
																										</children>
																									</tgridrow>
																								</children>
																							</tgridbody-rows>
																						</children>
																						<wizard-data-repeat>
																							<children/>
																						</wizard-data-repeat>
																						<wizard-data-rows>
																							<children/>
																						</wizard-data-rows>
																						<wizard-data-columns>
																							<children/>
																						</wizard-data-columns>
																					</tgrid>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="tns:Assignee">
																		<children>
																			<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																				<properties border="0" width="100%"/>
																				<children>
																					<tgridbody-cols>
																						<children>
																							<tgridcol/>
																							<tgridcol>
																								<styles width="100px"/>
																							</tgridcol>
																						</children>
																					</tgridbody-cols>
																					<tgridbody-rows>
																						<children>
																							<tgridrow>
																								<properties bgcolor="#d2d2d2"/>
																								<children>
																									<tgridcell>
																										<properties valign="top"/>
																										<children>
																											<paragraph>
																												<styles font-weight="bold"/>
																												<children>
																													<text fixtext="Правоприемник"/>
																												</children>
																											</paragraph>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<properties valign="top"/>
																										<styles text-align="right"/>
																										<children>
																											<template subtype="element" match="E:EntryTime">
																												<children>
																													<content subtype="regular">
																														<styles font-size="x-small" font-style="italic"/>
																														<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																											<template subtype="element" match="T40:OperationType">
																												<children>
																													<paragraph>
																														<children>
																															<text fixtext="(">
																																<styles font-size="x-small" font-style="italic"/>
																															</text>
																															<content subtype="regular">
																																<styles font-size="x-small" font-style="italic"/>
																																<format basic-type="xsd" datatype="string"/>
																															</content>
																															<text fixtext=")">
																																<styles font-size="x-small" font-style="italic"/>
																															</text>
																														</children>
																													</paragraph>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																								</children>
																							</tgridrow>
																						</children>
																					</tgridbody-rows>
																				</children>
																				<wizard-data-repeat>
																					<children/>
																				</wizard-data-repeat>
																				<wizard-data-rows>
																					<children/>
																				</wizard-data-rows>
																				<wizard-data-columns>
																					<children/>
																				</wizard-data-columns>
																			</tgrid>
																			<template subtype="element" match="REL3:Type">
																				<children>
																					<template subtype="element" match="T3:Code">
																						<children>
																							<text fixtext="Вид правоприемство: "/>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="REL3:RelatedSubjects">
																				<children>
																					<calltemplate subtype="named" match="Subject">
																						<parameters/>
																					</calltemplate>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length(tns:Belonging)&gt;0">
																				<children>
																					<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																						<properties bgcolor="#e1e1e1" border="0" width="100%"/>
																						<children>
																							<tgridbody-cols>
																								<children>
																									<tgridcol/>
																								</children>
																							</tgridbody-cols>
																							<tgridbody-rows>
																								<children>
																									<tgridrow>
																										<properties bgcolor="#e1e1e1" valign="top"/>
																										<children>
																											<tgridcell>
																												<properties valign="top"/>
																												<children>
																													<paragraph paragraphtag="h3">
																														<styles text-decoration="underline"/>
																														<children>
																															<text fixtext="Принадлежност">
																																<styles font-size="24px"/>
																															</text>
																														</children>
																													</paragraph>
																												</children>
																											</tgridcell>
																										</children>
																									</tgridrow>
																								</children>
																							</tgridbody-rows>
																						</children>
																						<wizard-data-repeat>
																							<children/>
																						</wizard-data-repeat>
																						<wizard-data-rows>
																							<children/>
																						</wizard-data-rows>
																						<wizard-data-columns>
																							<children/>
																						</wizard-data-columns>
																					</tgrid>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="tns:Belonging">
																		<children>
																			<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																				<properties border="0" width="100%"/>
																				<children>
																					<tgridbody-cols>
																						<children>
																							<tgridcol/>
																							<tgridcol>
																								<styles width="100px"/>
																							</tgridcol>
																						</children>
																					</tgridbody-cols>
																					<tgridbody-rows>
																						<children>
																							<tgridrow>
																								<properties bgcolor="#d2d2d2"/>
																								<children>
																									<tgridcell>
																										<properties valign="top"/>
																										<children>
																											<paragraph>
																												<styles font-weight="bold"/>
																												<children>
																													<text fixtext="Субект"/>
																												</children>
																											</paragraph>
																										</children>
																									</tgridcell>
																									<tgridcell>
																										<properties valign="top"/>
																										<styles text-align="right"/>
																										<children>
																											<template subtype="element" match="E:EntryTime">
																												<children>
																													<content subtype="regular">
																														<styles font-size="x-small" font-style="italic"/>
																														<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																											<template subtype="element" match="T40:OperationType">
																												<children>
																													<paragraph>
																														<styles text-align="right"/>
																														<children>
																															<text fixtext="(">
																																<styles font-size="x-small" font-style="italic"/>
																															</text>
																															<content subtype="regular">
																																<styles font-size="x-small" font-style="italic"/>
																																<format basic-type="xsd" datatype="string"/>
																															</content>
																															<text fixtext=")">
																																<styles font-size="x-small" font-style="italic"/>
																															</text>
																														</children>
																													</paragraph>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</tgridcell>
																								</children>
																							</tgridrow>
																						</children>
																					</tgridbody-rows>
																				</children>
																				<wizard-data-repeat>
																					<children/>
																				</wizard-data-repeat>
																				<wizard-data-rows>
																					<children/>
																				</wizard-data-rows>
																				<wizard-data-columns>
																					<children/>
																				</wizard-data-columns>
																			</tgrid>
																			<template subtype="element" match="REL2:Type">
																				<children>
																					<template subtype="element" match="T3:Code">
																						<children>
																							<text fixtext="Вид принадлежност: "/>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																						<variables/>
																					</template>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="REL2:RelatedSubject">
																				<children>
																					<calltemplate subtype="named" match="Subject">
																						<parameters/>
																					</calltemplate>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</conditionbranch>
														</children>
													</condition>
												</children>
												<variables/>
											</template>
										</children>
									</conditionbranch>
									<conditionbranch>
										<children>
											<text fixtext="Не е открит субект на БУЛСТАТ по зададените критерии!"/>
										</children>
									</conditionbranch>
								</children>
							</condition>
						</children>
						<variables/>
					</template>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<designfragments>
		<children>
			<globaltemplate subtype="named" match="Subject">
				<parameters/>
				<children>
					<template subtype="element" match="T25:UIC">
						<children>
							<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
								<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
								<children>
									<tgridbody-cols>
										<children>
											<tgridcol/>
											<tgridcol>
												<styles width="100px"/>
											</tgridcol>
										</children>
									</tgridbody-cols>
									<tgridbody-rows>
										<children>
											<tgridrow>
												<children>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<paragraph>
																<styles font-weight="normal"/>
																<children>
																	<text fixtext="Код по булстат:">
																		<styles font-weight="bold"/>
																	</text>
																	<text fixtext=" "/>
																	<template subtype="element" match="T251:UIC">
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="T251:UICType">
																		<children>
																			<template subtype="element" match="T3:Code">
																				<children>
																					<text fixtext=" (тип: "/>
																					<content subtype="regular">
																						<format basic-type="xsd" datatype="string"/>
																					</content>
																					<text fixtext=")"/>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</paragraph>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<styles text-align="right"/>
														<children>
															<template subtype="element" match="E:EntryTime">
																<children>
																	<content subtype="regular">
																		<styles font-size="x-small" font-style="italic"/>
																		<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
												</children>
											</tgridrow>
										</children>
									</tgridbody-rows>
								</children>
								<wizard-data-repeat>
									<children/>
								</wizard-data-repeat>
								<wizard-data-rows>
									<children/>
								</wizard-data-rows>
								<wizard-data-columns>
									<children/>
								</wizard-data-columns>
							</tgrid>
						</children>
						<variables/>
					</template>
					<template subtype="element" match="T25:SubjectType">
						<children>
							<template subtype="element" match="T3:Code">
								<children>
									<paragraph>
										<children>
											<text fixtext="Вид на субект (НФЛ, ФЗЛ, Държава, Неизвестен):">
												<styles font-weight="bold"/>
											</text>
											<text fixtext=" "/>
											<content subtype="regular">
												<format basic-type="xsd" datatype="string"/>
											</content>
										</children>
									</paragraph>
								</children>
								<variables/>
							</template>
						</children>
						<variables/>
					</template>
					<template subtype="element" match="T25:LegalEntitySubject">
						<children>
							<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
								<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
								<children>
									<tgridbody-cols>
										<children>
											<tgridcol/>
											<tgridcol>
												<styles width="100px"/>
											</tgridcol>
										</children>
									</tgridbody-cols>
									<tgridbody-rows>
										<children>
											<tgridrow>
												<children>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<paragraph>
																<styles font-weight="bold"/>
																<children>
																	<text fixtext="Юридическо лице">
																		<styles text-decoration="underline"/>
																	</text>
																</children>
															</paragraph>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<styles text-align="right"/>
														<children>
															<template subtype="element" match="E:EntryTime">
																<children>
																	<content subtype="regular">
																		<styles font-size="x-small" font-style="italic"/>
																		<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
												</children>
											</tgridrow>
										</children>
									</tgridbody-rows>
								</children>
								<wizard-data-repeat>
									<children/>
								</wizard-data-repeat>
								<wizard-data-rows>
									<children/>
								</wizard-data-rows>
								<wizard-data-columns>
									<children/>
								</wizard-data-columns>
							</tgrid>
							<template subtype="element" match="T22:CyrillicFullName">
								<children>
									<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
										<properties border="0" width="100%"/>
										<children>
											<tgridbody-cols>
												<children>
													<tgridcol>
														<styles width="250px"/>
													</tgridcol>
													<tgridcol/>
													<tgridcol>
														<styles width="100px"/>
													</tgridcol>
												</children>
											</tgridbody-cols>
											<tgridbody-rows>
												<children>
													<tgridrow>
														<children>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<paragraph>
																		<children>
																			<text fixtext="Пълно наименование на кирилица"/>
																			<text fixtext=":">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</paragraph>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
															</tgridcell>
														</children>
													</tgridrow>
												</children>
											</tgridbody-rows>
										</children>
										<wizard-data-repeat>
											<children/>
										</wizard-data-repeat>
										<wizard-data-rows>
											<children/>
										</wizard-data-rows>
										<wizard-data-columns>
											<children/>
										</wizard-data-columns>
									</tgrid>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:CyrillicShortName">
								<children>
									<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
										<properties border="0" width="100%"/>
										<children>
											<tgridbody-cols>
												<children>
													<tgridcol>
														<styles width="250px"/>
													</tgridcol>
													<tgridcol/>
													<tgridcol>
														<styles width="100px"/>
													</tgridcol>
												</children>
											</tgridbody-cols>
											<tgridbody-rows>
												<children>
													<tgridrow>
														<children>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<paragraph>
																		<children>
																			<text fixtext="Кратко наименование на кирилица"/>
																			<text fixtext=":">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</paragraph>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
															</tgridcell>
														</children>
													</tgridrow>
												</children>
											</tgridbody-rows>
										</children>
										<wizard-data-repeat>
											<children/>
										</wizard-data-repeat>
										<wizard-data-rows>
											<children/>
										</wizard-data-rows>
										<wizard-data-columns>
											<children/>
										</wizard-data-columns>
									</tgrid>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:LatinFullName">
								<children>
									<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
										<properties border="0" width="100%"/>
										<children>
											<tgridbody-cols>
												<children>
													<tgridcol>
														<styles width="250px"/>
													</tgridcol>
													<tgridcol/>
													<tgridcol>
														<styles width="100px"/>
													</tgridcol>
												</children>
											</tgridbody-cols>
											<tgridbody-rows>
												<children>
													<tgridrow>
														<children>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<paragraph>
																		<children>
																			<text fixtext="Пълно наименование на латиница"/>
																			<text fixtext=":">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</paragraph>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
															</tgridcell>
														</children>
													</tgridrow>
												</children>
											</tgridbody-rows>
										</children>
										<wizard-data-repeat>
											<children/>
										</wizard-data-repeat>
										<wizard-data-rows>
											<children/>
										</wizard-data-rows>
										<wizard-data-columns>
											<children/>
										</wizard-data-columns>
									</tgrid>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:Country">
								<children>
									<template subtype="element" match="T3:Code">
										<children>
											<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
												<properties border="0" width="100%"/>
												<children>
													<tgridbody-cols>
														<children>
															<tgridcol>
																<styles width="250px"/>
															</tgridcol>
															<tgridcol/>
															<tgridcol>
																<styles width="100px"/>
															</tgridcol>
														</children>
													</tgridbody-cols>
													<tgridbody-rows>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<paragraph>
																				<children>
																					<text fixtext="Държава"/>
																					<text fixtext=":">
																						<styles font-weight="bold"/>
																					</text>
																				</children>
																			</paragraph>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
													</tgridbody-rows>
												</children>
												<wizard-data-repeat>
													<children/>
												</wizard-data-repeat>
												<wizard-data-rows>
													<children/>
												</wizard-data-rows>
												<wizard-data-columns>
													<children/>
												</wizard-data-columns>
											</tgrid>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:LegalForm">
								<children>
									<template subtype="element" match="T3:Code">
										<children>
											<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
												<properties border="0" width="100%"/>
												<children>
													<tgridbody-cols>
														<children>
															<tgridcol>
																<styles width="250px"/>
															</tgridcol>
															<tgridcol/>
															<tgridcol>
																<styles width="100px"/>
															</tgridcol>
														</children>
													</tgridbody-cols>
													<tgridbody-rows>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<paragraph>
																				<children>
																					<text fixtext="Код на правна форма"/>
																					<text fixtext=":">
																						<styles font-weight="bold"/>
																					</text>
																				</children>
																			</paragraph>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
													</tgridbody-rows>
												</children>
												<wizard-data-repeat>
													<children/>
												</wizard-data-repeat>
												<wizard-data-rows>
													<children/>
												</wizard-data-rows>
												<wizard-data-columns>
													<children/>
												</wizard-data-columns>
											</tgrid>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:LegalStatute">
								<children>
									<template subtype="element" match="T3:Code">
										<children>
											<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
												<properties border="0" width="100%"/>
												<children>
													<tgridbody-cols>
														<children>
															<tgridcol>
																<styles width="250px"/>
															</tgridcol>
															<tgridcol/>
															<tgridcol>
																<styles width="100px"/>
															</tgridcol>
														</children>
													</tgridbody-cols>
													<tgridbody-rows>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<paragraph>
																				<children>
																					<text fixtext="Код на юридически статус"/>
																					<text fixtext=":">
																						<styles font-weight="bold"/>
																					</text>
																				</children>
																			</paragraph>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
													</tgridbody-rows>
												</children>
												<wizard-data-repeat>
													<children/>
												</wizard-data-repeat>
												<wizard-data-rows>
													<children/>
												</wizard-data-rows>
												<wizard-data-columns>
													<children/>
												</wizard-data-columns>
											</tgrid>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:SubjectGroup">
								<children>
									<template subtype="element" match="T3:Code">
										<children>
											<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
												<properties border="0" width="100%"/>
												<children>
													<tgridbody-cols>
														<children>
															<tgridcol>
																<styles width="250px"/>
															</tgridcol>
															<tgridcol/>
															<tgridcol>
																<styles width="100px"/>
															</tgridcol>
														</children>
													</tgridbody-cols>
													<tgridbody-rows>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<paragraph>
																				<children>
																					<text fixtext="Код на група субекти"/>
																					<text fixtext=":">
																						<styles font-weight="bold"/>
																					</text>
																				</children>
																			</paragraph>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
													</tgridbody-rows>
												</children>
												<wizard-data-repeat>
													<children/>
												</wizard-data-repeat>
												<wizard-data-rows>
													<children/>
												</wizard-data-rows>
												<wizard-data-columns>
													<children/>
												</wizard-data-columns>
											</tgrid>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:SubordinateLevel">
								<children>
									<template subtype="element" match="T3:Code">
										<children>
											<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
												<properties border="0" width="100%"/>
												<children>
													<tgridbody-cols>
														<children>
															<tgridcol>
																<styles width="250px"/>
															</tgridcol>
															<tgridcol/>
															<tgridcol>
																<styles width="100px"/>
															</tgridcol>
														</children>
													</tgridbody-cols>
													<tgridbody-rows>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<paragraph>
																				<children>
																					<text fixtext="Код на ниво на подчиненост"/>
																					<text fixtext=":">
																						<styles font-weight="bold"/>
																					</text>
																				</children>
																			</paragraph>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
													</tgridbody-rows>
												</children>
												<wizard-data-repeat>
													<children/>
												</wizard-data-repeat>
												<wizard-data-rows>
													<children/>
												</wizard-data-rows>
												<wizard-data-columns>
													<children/>
												</wizard-data-columns>
											</tgrid>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
							<template subtype="element" match="T22:TRStatus">
								<children>
									<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
										<properties border="0" width="100%"/>
										<children>
											<tgridbody-cols>
												<children>
													<tgridcol>
														<styles width="250px"/>
													</tgridcol>
													<tgridcol/>
													<tgridcol>
														<styles width="100px"/>
													</tgridcol>
												</children>
											</tgridbody-cols>
											<tgridbody-rows>
												<children>
													<tgridrow>
														<children>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<paragraph>
																		<children>
																			<text fixtext="Статус от Търговски регистър"/>
																			<text fixtext=":">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</paragraph>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
																<children>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
															</tgridcell>
															<tgridcell>
																<properties valign="top"/>
															</tgridcell>
														</children>
													</tgridrow>
												</children>
											</tgridbody-rows>
										</children>
										<wizard-data-repeat>
											<children/>
										</wizard-data-repeat>
										<wizard-data-rows>
											<children/>
										</wizard-data-rows>
										<wizard-data-columns>
											<children/>
										</wizard-data-columns>
									</tgrid>
								</children>
								<variables/>
							</template>
						</children>
						<variables/>
					</template>
					<template subtype="element" match="T25:NaturalPersonSubject">
						<children>
							<condition>
								<children>
									<conditionbranch xpath="string-length( E:EntryTime ) &gt; 0 or
string-length( T23:Country/T3:Code )&gt; 0 or
string-length( T23:EGN )&gt; 0 or
string-length( T23:LNC )&gt; 0 or
string-length( T23:CyrillicName )&gt; 0 or
string-length( T23:LatinName )&gt; 0 or
string-length( T23:BirthDate )&gt; 0 or
string-length( T23:IdentificationDoc/E:EntryTime ) &gt; 0 or
string-length(  T23:IdentificationDoc/T171:IDType/T3:Code ) &gt; 0 or
string-length( T23:IdentificationDoc/T171:IDNumber )  &gt; 0 or
string-length( T23:IdentificationDoc/T171:Country/T3:Code ) &gt; 0 or
string-length( T23:IdentificationDoc/T171:IssueDate ) &gt; 0 or
string-length( T23:IdentificationDoc/T171:ExpiryDate )&gt; 0">
										<children>
											<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
												<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
												<children>
													<tgridbody-cols>
														<children>
															<tgridcol/>
															<tgridcol>
																<styles width="100px"/>
															</tgridcol>
														</children>
													</tgridbody-cols>
													<tgridbody-rows>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<paragraph>
																				<styles font-weight="bold"/>
																				<children>
																					<text fixtext="Физическо лице:">
																						<styles text-decoration="underline"/>
																					</text>
																				</children>
																			</paragraph>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																		<styles text-align="right"/>
																		<children>
																			<template subtype="element" match="E:EntryTime">
																				<children>
																					<content subtype="regular">
																						<styles font-size="x-small" font-style="italic"/>
																						<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																					</content>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
													</tgridbody-rows>
												</children>
												<wizard-data-repeat>
													<children/>
												</wizard-data-repeat>
												<wizard-data-rows>
													<children/>
												</wizard-data-rows>
												<wizard-data-columns>
													<children/>
												</wizard-data-columns>
											</tgrid>
											<template subtype="element" match="T23:CyrillicName">
												<children>
													<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
														<properties border="0" width="100%"/>
														<children>
															<tgridbody-cols>
																<children>
																	<tgridcol>
																		<styles width="250px"/>
																	</tgridcol>
																	<tgridcol/>
																	<tgridcol>
																		<styles width="100px"/>
																	</tgridcol>
																</children>
															</tgridbody-cols>
															<tgridbody-rows>
																<children>
																	<tgridrow>
																		<children>
																			<tgridcell>
																				<properties valign="top"/>
																				<children>
																					<paragraph>
																						<children>
																							<text fixtext="Име на кирилица"/>
																							<text fixtext=":">
																								<styles font-weight="bold"/>
																							</text>
																						</children>
																					</paragraph>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<properties valign="top"/>
																				<children>
																					<content subtype="regular">
																						<format basic-type="xsd" datatype="string"/>
																					</content>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<properties valign="top"/>
																			</tgridcell>
																		</children>
																	</tgridrow>
																</children>
															</tgridbody-rows>
														</children>
														<wizard-data-repeat>
															<children/>
														</wizard-data-repeat>
														<wizard-data-rows>
															<children/>
														</wizard-data-rows>
														<wizard-data-columns>
															<children/>
														</wizard-data-columns>
													</tgrid>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="T23:LatinName">
												<children>
													<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
														<properties border="0" width="100%"/>
														<children>
															<tgridbody-cols>
																<children>
																	<tgridcol>
																		<styles width="250px"/>
																	</tgridcol>
																	<tgridcol/>
																	<tgridcol>
																		<styles width="100px"/>
																	</tgridcol>
																</children>
															</tgridbody-cols>
															<tgridbody-rows>
																<children>
																	<tgridrow>
																		<children>
																			<tgridcell>
																				<properties valign="top"/>
																				<children>
																					<paragraph>
																						<children>
																							<text fixtext="Име на латиница"/>
																							<text fixtext=":">
																								<styles font-weight="bold"/>
																							</text>
																						</children>
																					</paragraph>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<properties valign="top"/>
																				<children>
																					<content subtype="regular">
																						<format basic-type="xsd" datatype="string"/>
																					</content>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<properties valign="top"/>
																			</tgridcell>
																		</children>
																	</tgridrow>
																</children>
															</tgridbody-rows>
														</children>
														<wizard-data-repeat>
															<children/>
														</wizard-data-repeat>
														<wizard-data-rows>
															<children/>
														</wizard-data-rows>
														<wizard-data-columns>
															<children/>
														</wizard-data-columns>
													</tgrid>
												</children>
												<variables/>
											</template>
											<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
												<properties border="0" width="100%"/>
												<children>
													<tgridbody-cols>
														<children>
															<tgridcol>
																<styles width="250px"/>
															</tgridcol>
															<tgridcol/>
															<tgridcol>
																<styles width="100px"/>
															</tgridcol>
														</children>
													</tgridbody-cols>
													<tgridbody-rows>
														<children>
															<tgridrow>
																<children>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<paragraph>
																				<children>
																					<text fixtext="Идентификатор:"/>
																				</children>
																			</paragraph>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																		<children>
																			<template subtype="element" match="T23:EGN">
																				<children>
																					<paragraph>
																						<children>
																							<text fixtext="ЕГН: "/>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																					</paragraph>
																				</children>
																				<variables/>
																			</template>
																			<template subtype="element" match="T23:LNC">
																				<children>
																					<paragraph>
																						<children>
																							<text fixtext="ЛНЧ: "/>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																					</paragraph>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</tgridcell>
																	<tgridcell>
																		<properties valign="top"/>
																	</tgridcell>
																</children>
															</tgridrow>
														</children>
													</tgridbody-rows>
												</children>
												<wizard-data-repeat>
													<children/>
												</wizard-data-repeat>
												<wizard-data-rows>
													<children/>
												</wizard-data-rows>
												<wizard-data-columns>
													<children/>
												</wizard-data-columns>
											</tgrid>
											<template subtype="element" match="T23:BirthDate">
												<children>
													<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
														<properties border="0" width="100%"/>
														<children>
															<tgridbody-cols>
																<children>
																	<tgridcol>
																		<styles width="250px"/>
																	</tgridcol>
																	<tgridcol/>
																	<tgridcol>
																		<styles width="100px"/>
																	</tgridcol>
																</children>
															</tgridbody-cols>
															<tgridbody-rows>
																<children>
																	<tgridrow>
																		<children>
																			<tgridcell>
																				<properties valign="top"/>
																				<children>
																					<paragraph>
																						<children>
																							<text fixtext="Дата на раждане:"/>
																						</children>
																					</paragraph>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<properties valign="top"/>
																				<children>
																					<content subtype="regular">
																						<format basic-type="xsd" datatype="string"/>
																					</content>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<properties valign="top"/>
																			</tgridcell>
																		</children>
																	</tgridrow>
																</children>
															</tgridbody-rows>
														</children>
														<wizard-data-repeat>
															<children/>
														</wizard-data-repeat>
														<wizard-data-rows>
															<children/>
														</wizard-data-rows>
														<wizard-data-columns>
															<children/>
														</wizard-data-columns>
													</tgrid>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="T23:Country">
												<children>
													<template subtype="element" match="T3:Code">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																			<tgridcol>
																				<styles width="100px"/>
																			</tgridcol>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph>
																								<children>
																									<text fixtext="Гражданство (код на държава)"/>
																									<text fixtext=":">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
												</children>
												<variables/>
											</template>
											<template subtype="element" match="T23:BirthDate">
												<variables/>
											</template>
											<template subtype="element" match="T23:IdentificationDoc">
												<children>
													<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
														<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
														<children>
															<tgridbody-cols>
																<children>
																	<tgridcol/>
																	<tgridcol>
																		<styles width="100px"/>
																	</tgridcol>
																</children>
															</tgridbody-cols>
															<tgridbody-rows>
																<children>
																	<tgridrow>
																		<children>
																			<tgridcell>
																				<properties valign="top"/>
																				<children>
																					<paragraph>
																						<styles font-weight="bold"/>
																						<children>
																							<text fixtext="Документ за самоличност">
																								<styles text-decoration="underline"/>
																							</text>
																						</children>
																					</paragraph>
																				</children>
																			</tgridcell>
																			<tgridcell>
																				<properties valign="top"/>
																				<styles text-align="right"/>
																				<children>
																					<template subtype="element" match="T23:IdentificationDoc">
																						<children>
																							<template subtype="element" match="E:EntryTime">
																								<children>
																									<content subtype="regular">
																										<styles font-size="x-small" font-style="italic"/>
																										<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																				</children>
																			</tgridcell>
																		</children>
																	</tgridrow>
																</children>
															</tgridbody-rows>
														</children>
														<wizard-data-repeat>
															<children/>
														</wizard-data-repeat>
														<wizard-data-rows>
															<children/>
														</wizard-data-rows>
														<wizard-data-columns>
															<children/>
														</wizard-data-columns>
													</tgrid>
													<template subtype="element" match="T171:IDType">
														<children>
															<template subtype="element" match="T3:Code">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<children>
																											<text fixtext="Вид"/>
																											<text fixtext=":">
																												<styles font-weight="bold"/>
																											</text>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="string"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="T171:IDNumber">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph>
																								<children>
																									<text fixtext="Номер на документ"/>
																									<text fixtext=":">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="T171:Country">
														<children>
															<template subtype="element" match="T3:Code">
																<children>
																	<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																		<properties border="0" width="100%"/>
																		<children>
																			<tgridbody-cols>
																				<children>
																					<tgridcol>
																						<styles width="250px"/>
																					</tgridcol>
																					<tgridcol/>
																				</children>
																			</tgridbody-cols>
																			<tgridbody-rows>
																				<children>
																					<tgridrow>
																						<children>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<paragraph>
																										<children>
																											<text fixtext="Държава издала документа"/>
																											<text fixtext=":">
																												<styles font-weight="bold"/>
																											</text>
																										</children>
																									</paragraph>
																								</children>
																							</tgridcell>
																							<tgridcell>
																								<properties valign="top"/>
																								<children>
																									<content subtype="regular">
																										<format basic-type="xsd" datatype="string"/>
																									</content>
																								</children>
																							</tgridcell>
																						</children>
																					</tgridrow>
																				</children>
																			</tgridbody-rows>
																		</children>
																		<wizard-data-repeat>
																			<children/>
																		</wizard-data-repeat>
																		<wizard-data-rows>
																			<children/>
																		</wizard-data-rows>
																		<wizard-data-columns>
																			<children/>
																		</wizard-data-columns>
																	</tgrid>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="T171:IssueDate">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph>
																								<children>
																									<text fixtext="Дата на издаване"/>
																									<text fixtext=":">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
													<template subtype="element" match="T171:ExpiryDate">
														<children>
															<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
																<properties border="0" width="100%"/>
																<children>
																	<tgridbody-cols>
																		<children>
																			<tgridcol>
																				<styles width="250px"/>
																			</tgridcol>
																			<tgridcol/>
																		</children>
																	</tgridbody-cols>
																	<tgridbody-rows>
																		<children>
																			<tgridrow>
																				<children>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<paragraph>
																								<children>
																									<text fixtext="Дата на валидност"/>
																									<text fixtext=":">
																										<styles font-weight="bold"/>
																									</text>
																								</children>
																							</paragraph>
																						</children>
																					</tgridcell>
																					<tgridcell>
																						<properties valign="top"/>
																						<children>
																							<content subtype="regular">
																								<format basic-type="xsd" datatype="string"/>
																							</content>
																						</children>
																					</tgridcell>
																				</children>
																			</tgridrow>
																		</children>
																	</tgridbody-rows>
																</children>
																<wizard-data-repeat>
																	<children/>
																</wizard-data-repeat>
																<wizard-data-rows>
																	<children/>
																</wizard-data-rows>
																<wizard-data-columns>
																	<children/>
																</wizard-data-columns>
															</tgrid>
														</children>
														<variables/>
													</template>
												</children>
												<variables/>
											</template>
										</children>
									</conditionbranch>
									<conditionbranch/>
								</children>
							</condition>
						</children>
						<variables/>
					</template>
					<template subtype="element" match="T25:CountrySubject">
						<children>
							<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
								<properties border="0" width="100%"/>
								<children>
									<tgridbody-cols>
										<children>
											<tgridcol>
												<styles width="250px"/>
											</tgridcol>
											<tgridcol/>
											<tgridcol>
												<styles width="100px"/>
											</tgridcol>
										</children>
									</tgridbody-cols>
									<tgridbody-rows>
										<children>
											<tgridrow>
												<children>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<paragraph>
																<children>
																	<text fixtext="Държава">
																		<styles font-weight="bold" text-decoration="underline"/>
																	</text>
																</children>
															</paragraph>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<template subtype="element" match="T3:Code">
																<children>
																	<text fixtext="Код: "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
													</tgridcell>
												</children>
											</tgridrow>
										</children>
									</tgridbody-rows>
								</children>
								<wizard-data-repeat>
									<children/>
								</wizard-data-repeat>
								<wizard-data-rows>
									<children/>
								</wizard-data-rows>
								<wizard-data-columns>
									<children/>
								</wizard-data-columns>
							</tgrid>
						</children>
						<variables/>
					</template>
					<condition>
						<children>
							<conditionbranch xpath="string-length(T25:Communications)&gt;0">
								<children>
									<paragraph>
										<styles font-weight="bold" text-align="left"/>
										<children>
											<text fixtext="Комуникации">
												<styles text-decoration="underline"/>
											</text>
										</children>
									</paragraph>
								</children>
							</conditionbranch>
						</children>
					</condition>
					<template subtype="element" match="T25:Communications">
						<children>
							<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
								<properties border="0" width="100%"/>
								<children>
									<tgridbody-cols>
										<children>
											<tgridcol>
												<styles width="250px"/>
											</tgridcol>
											<tgridcol/>
											<tgridcol>
												<styles width="100px"/>
											</tgridcol>
										</children>
									</tgridbody-cols>
									<tgridbody-rows>
										<children>
											<tgridrow>
												<children>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<paragraph>
																<styles font-weight="bold"/>
																<children>
																	<template subtype="element" match="T28:Type">
																		<children>
																			<template subtype="element" match="T3:Code">
																				<children>
																					<text fixtext="Код: "/>
																					<content subtype="regular">
																						<format basic-type="xsd" datatype="string"/>
																					</content>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</paragraph>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<template subtype="element" match="T28:Value">
																<children>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<styles text-align="right"/>
														<children>
															<template subtype="element" match="E:EntryTime">
																<children>
																	<content subtype="regular">
																		<styles font-size="x-small" font-style="italic"/>
																		<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
												</children>
											</tgridrow>
										</children>
									</tgridbody-rows>
								</children>
								<wizard-data-repeat>
									<children/>
								</wizard-data-repeat>
								<wizard-data-rows>
									<children/>
								</wizard-data-rows>
								<wizard-data-columns>
									<children/>
								</wizard-data-columns>
							</tgrid>
						</children>
						<variables/>
					</template>
					<condition>
						<children>
							<conditionbranch xpath="string-length(T25:Addresses)&gt;0">
								<children>
									<paragraph>
										<styles font-weight="bold" text-align="left"/>
										<children>
											<text fixtext="Адреси">
												<styles text-decoration="underline"/>
											</text>
										</children>
									</paragraph>
								</children>
							</conditionbranch>
						</children>
					</condition>
					<template subtype="element" match="T25:Addresses">
						<children>
							<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
								<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>
								<children>
									<tgridbody-cols>
										<children>
											<tgridcol/>
											<tgridcol>
												<styles width="100px"/>
											</tgridcol>
										</children>
									</tgridbody-cols>
									<tgridbody-rows>
										<children>
											<tgridrow>
												<children>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<template subtype="element" match="T8:AddressType">
																<children>
																	<template subtype="element" match="T3:Code">
																		<children>
																			<text fixtext="Вид на адреса (код): ">
																				<styles text-decoration="underline"/>
																			</text>
																			<content subtype="regular">
																				<styles text-decoration="underline"/>
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<styles text-align="right"/>
														<children>
															<template subtype="element" match="E:EntryTime">
																<children>
																	<content subtype="regular">
																		<styles font-size="x-small" font-style="italic"/>
																		<format basic-type="xsd" string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
												</children>
											</tgridrow>
										</children>
									</tgridbody-rows>
								</children>
								<wizard-data-repeat>
									<children/>
								</wizard-data-repeat>
								<wizard-data-rows>
									<children/>
								</wizard-data-rows>
								<wizard-data-columns>
									<children/>
								</wizard-data-columns>
							</tgrid>
							<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
								<properties border="0" width="100%"/>
								<children>
									<tgridbody-cols>
										<children>
											<tgridcol>
												<styles width="250px"/>
											</tgridcol>
											<tgridcol/>
										</children>
									</tgridbody-cols>
									<tgridbody-rows>
										<children>
											<tgridrow>
												<children>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<paragraph>
																<children>
																	<text fixtext="Населено място"/>
																</children>
															</paragraph>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<template subtype="element" match="T8:Country">
																<children>
																	<template subtype="element" match="T3:Code">
																		<children>
																			<text fixtext="Код на държава: "/>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:ForeignLocation">
																<children>
																	<text fixtext=", населено място в чужбина: "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:Location">
																<children>
																	<template subtype="element" match="T3:Code">
																		<children>
																			<text fixtext=", населено място в България (код от ЕКАТТЕ): "/>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:Region">
																<children>
																	<template subtype="element" match="T3:Code">
																		<children>
																			<text fixtext=", район (код от ЕКАТТЕ): "/>
																			<content subtype="regular">
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
												</children>
											</tgridrow>
										</children>
									</tgridbody-rows>
								</children>
								<wizard-data-repeat>
									<children/>
								</wizard-data-repeat>
								<wizard-data-rows>
									<children/>
								</wizard-data-rows>
								<wizard-data-columns>
									<children/>
								</wizard-data-columns>
							</tgrid>
							<tgrid tablegen-filter-periods-to-month="12" tablegen-filter-periods-to-day="31">
								<properties border="0" width="100%"/>
								<children>
									<tgridbody-cols>
										<children>
											<tgridcol>
												<styles width="250px"/>
											</tgridcol>
											<tgridcol/>
										</children>
									</tgridbody-cols>
									<tgridbody-rows>
										<children>
											<tgridrow>
												<children>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<paragraph>
																<children>
																	<text fixtext="Описание"/>
																</children>
															</paragraph>
														</children>
													</tgridcell>
													<tgridcell>
														<properties valign="top"/>
														<children>
															<template subtype="element" match="T8:Street">
																<children>
																	<text fixtext="ул./бул./ж.к : "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:StreetNumber">
																<children>
																	<text fixtext=", №: "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:Building">
																<children>
																	<text fixtext=", "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:Entrance">
																<children>
																	<text fixtext=", вх. "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:Floor">
																<children>
																	<text fixtext=", ет. "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:Apartment">
																<children>
																	<text fixtext=", ап. "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:PostalCode">
																<children>
																	<text fixtext=", п.код. "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="T8:PostalBox">
																<children>
																	<text fixtext=", пощ. кут. "/>
																	<content subtype="regular">
																		<format basic-type="xsd" datatype="string"/>
																	</content>
																</children>
																<variables/>
															</template>
														</children>
													</tgridcell>
												</children>
											</tgridrow>
										</children>
									</tgridbody-rows>
								</children>
								<wizard-data-repeat>
									<children/>
								</wizard-data-repeat>
								<wizard-data-rows>
									<children/>
								</wizard-data-rows>
								<wizard-data-columns>
									<children/>
								</wizard-data-columns>
							</tgrid>
						</children>
						<variables/>
					</template>
					<template subtype="element" match="T25:Remark">
						<children>
							<text fixtext="Забележки:">
								<styles font-weight="bold"/>
							</text>
							<text fixtext=" "/>
							<content subtype="regular">
								<format basic-type="xsd" datatype="string"/>
							</content>
						</children>
						<variables/>
					</template>
				</children>
			</globaltemplate>
		</children>
	</designfragments>
	<xmltables/>
	<authentic-custom-toolbar-buttons/>
</structure>
